using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mooege.Net.GS.Message;
using Mooege.Net.GS.Message.Definitions.ACD;
using System.IO;
using SharpPcap.LibPcap;
using SharpPcap;
using PacketDotNet;

namespace GameMessageViewer
{


    public interface HighlightingNode
    {
        void Highlight(RichTextBox input);
        void Unhighlight(RichTextBox input);
        void Highlight(RichTextBox input, Color color);
    }

    public partial class MessageViewer : Form
    {
        MessageFilter filterWindow = new MessageFilter();
        RichTextBox temp = new RichTextBox();

        public MessageViewer()
        {
            InitializeComponent();
        }







        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tree.SelectedNode is MessageNode)
                DisplayMessage((tree.SelectedNode as MessageNode).gameMessage.AsText());
        }

        private void ApplyFilter()
        {
            foreach (BufferNode b in tree.Nodes)
                b.ApplyFilter(filterWindow.Filter);
        }

        private void tree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if(tree.SelectedNode != null)
                if(tree.SelectedNode.IsExpanded == false)
                    (tree.SelectedNode as HighlightingNode).Unhighlight(input);
        }

        private void tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node is BufferNode)
                (e.Node as BufferNode).Parse();
        }

        private void tree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            (e.Node as HighlightingNode).Unhighlight(input);
        }

        private void tree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            (e.Node as HighlightingNode).Highlight(input);
        }

        private void groupedNode_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is MessageNode)
                DisplayMessage((e.Node as MessageNode).gameMessage.AsText());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (TreeNode n in tree.Nodes)
                if (n is BufferNode)
                    (n as BufferNode).Parse();
        }

        private void messageFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterWindow.Show();
            ApplyFilter();
        }


        private void findAllMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find filter = new Find();

            if((filter.ShowDialog() != DialogResult.OK))
                return;

            string find = filter.Filter;
            tree.BeginUpdate();

            foreach (BufferNode bn in tree.Nodes)
            {
                bn.Collapse();

                foreach (MessageNode mn in bn.Nodes)
                    if (mn.gameMessage.ToString().Contains(find))
                    {
                        bn.BackColor = Color.Yellow;
                        mn.BackColor = Color.Yellow;
                        bn.Expand();
                    }
            }
            tree.EndUpdate();
        }

        /// <summary>
        /// Close application
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new AboutBox()).Show();
        }


        private void output_MouseMove(object sender, MouseEventArgs e)
        {
            int i = temp.GetCharIndexFromPosition(new Point(e.X, e.Y));
            temp.SelectionStart = i;
            temp.SelectionLength = 1;
            if (temp.SelectionFont.Underline)
            {
                if (output.Cursor != Cursors.Hand)
                    output.Cursor = Cursors.Hand;
            }
            else
                output.Cursor = Cursors.IBeam;
        }

        private void output_MouseClick(object sender, MouseEventArgs e)
        {
            int i = temp.GetCharIndexFromPosition(new Point(e.X, e.Y));

            temp.SelectionStart = i;
            temp.SelectionLength = 1;
            while (temp.SelectionFont.Underline)
                temp.SelectionStart--;
            temp.SelectionStart++;
            while (!temp.SelectedText.Contains(" ") && temp.SelectionStart + temp.SelectionLength < temp.Text.Length)
                temp.SelectionLength++;

            string text = temp.SelectedText;

            FindActor(text.Trim());
        }

        public void FindActor(string id)
        {
            foreach (TreeNode node in actors.Nodes)
                if (node.Tag as string == id)
                {
                    node.Expand();
                    node.BackColor = Color.Yellow;
                    node.EnsureVisible();
                    this.tabControl1.SelectTab(0);
                } else
                    node.BackColor = Color.White;
        }

        /// <summary>
        /// Underscore actor ids and add their sno name
        /// </summary>
        bool dontrec = false;
        private void DisplayMessage(string text)
        {
            if (dontrec) return;
            dontrec = true;
            temp.Text = text;
            output.Rtf = temp.Rtf;
            foreach (TreeNode tn in actors.Nodes)
            {
                int pos = temp.Find(tn.Tag as string);

                if (pos > -1)
                {
                    temp.Rtf = temp.Rtf.Replace(tn.Tag as string, tn.Text);
                    temp.Select(pos, tn.Text.Length);
                    temp.SelectionFont = new Font(output.Font, FontStyle.Underline);
                    temp.SelectionColor = Color.Blue;
                }
            }

            dontrec = false;
            temp.Size = output.Size;
            temp.Location = output.Location;
            output.Rtf = temp.Rtf;

            string[] words = output.Text.Split(new string[] { "0x", " ", "\n", ", " }, StringSplitOptions.RemoveEmptyEntries); // .Split(' ');
            List<string> usedKeys = new List<string>();

            // Bruteforce replacement of snos to their aliases
            if (trySNOAliasesToolStripMenuItem.Checked)
                foreach (string word in words)
                    if (word.Length > 5)  // "for hex values 0000FDC1 etc
                    {
                        try
                        {
                            //string raw = word.Replace("\n", "").Replace("0x", "");
                            int id = 0;
                            if (Int32.TryParse(word, System.Globalization.NumberStyles.HexNumber, null, out id))
                            {
                                if (usedKeys.Contains(id.ToString()) == false)
                                {
                                    usedKeys.Add(id.ToString());
                                    string alias = "";
                                    if (SNOAliases.Aliases.TryGetValue(id.ToString(), out alias))
                                    {
                                        output.Rtf = output.Rtf.Replace(word, word + ":" + alias);

                                        int pos = -1;
                                        while((pos = output.Text.IndexOf(alias, pos + 1)) > 0)
                                        {
                                        output.SelectionStart = pos;
                                        output.SelectionLength = alias.Length;
                                        output.SelectionColor = Color.OrangeRed;
                                        output.SelectionLength = 0;
                                        }

                                    }

                                }
                            }
                        }
                        catch (Exception) { System.Diagnostics.Debugger.Break(); }
                    }
            output.Refresh();
        }

        private void openPreparsedDumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Readable dumps|*.cap; *.pcap; *.txt; *.hex|"+
                         "Libpcap dumpy (*.cap; *.pcap)|*.cap; *.pcap|"+
                         "Mooege dumps (*.txt)|*.txt|"+
                         "Wireshark hex view (*.hex)|*.hex";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                actors.Nodes.Clear();
                tree.Nodes.Clear();

                if(Path.GetExtension(ofd.FileName).ToLower().Contains("txt"))
                    LoadDump(File.ReadAllText(ofd.FileName));
                if (Path.GetExtension(ofd.FileName).ToLower().Contains("cap"))
                    LoadPcap(ofd.FileName);
                if (Path.GetExtension(ofd.FileName).ToLower().Contains("hex"))
                    LoadWiresharkHex(File.ReadAllText(ofd.FileName));
            }
        }

    }
}
