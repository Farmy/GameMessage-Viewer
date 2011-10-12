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
            temp.TextChanged += this.temp_TextChanged;
            InitializeComponent();
        }

        private byte[] String_To_Bytes(string strInput)
        {
            // i variable used to hold position in string  
            int i = 0;
            // x variable used to hold byte array element position  
            int x = 0;
            // allocate byte array based on half of string length  
            byte[] bytes = new byte[(strInput.Length) / 2];
            // loop through the string - 2 bytes at a time converting  
            //  it to decimal equivalent and store in byte array  
            while (strInput.Length > i + 1)
            {
                long lngDecimal = Convert.ToInt32(strInput.Substring(i, 2), 16);
                bytes[x] = Convert.ToByte(lngDecimal);
                i = i + 2;
                ++x;
            }
            // return the finished byte array of decimal values  
            return bytes;
        }










        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (tree.SelectedNode is BufferNode)
            //   (tree.SelectedNode as BufferNode).Parse();

            if (tree.SelectedNode is MessageNode)
                temp.Text = (tree.SelectedNode as MessageNode).gameMessage.AsText();

            //(tree.SelectedNode as HighlightingNode).Highlight(input);
        }


        private void input_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                tree.Nodes.Clear();
                string text = input.Text;

                if (text.Contains(" "))
                {
                    String[] rows = text.Split('\n');
                    String currentBuffer = "";
                    text = "";

                    for (int i = 0; i < rows.Length; i++)
                    {
                        if (i > 0 && (rows[i].StartsWith(" ") ^ rows[i - 1].StartsWith(" ")))
                        {
                            Buffer buffer = new Buffer(String_To_Bytes(currentBuffer));
                            BufferNode newNode = new BufferNode(buffer, actors);
                            newNode.Start = text.Length;
                            newNode.BackColor = rows[i].StartsWith(" ") ? newNode.BackColor = Color.LightCoral : Color.LightBlue;
                            tree.Nodes.Add(newNode);
                            text += currentBuffer;
                            currentBuffer = "";
                        }

                        currentBuffer += (rows[i].StartsWith(" ") ? rows[i].Substring(14, 3 * 16) : rows[i].Substring(10, 3 * 16)).Trim().Replace(" ", "");
                    }
                }

                else
                {
                    Buffer buffer = new Buffer(String_To_Bytes(text));
                    BufferNode newNode = new BufferNode(buffer, actors);
                    newNode.Parse();
                    tree.Nodes.Add(newNode);
                }

                input.Text = text;
            }
            ApplyFilter();
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


        private void LoadDump(string text)
        {
            tree.Nodes.Clear();


            String[] rows = text.Split('\n');
            String currentBuffer = "";
            text = "";
            string currentDirection = "";

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].Length > 3)
                {
                    if (i > 0 && rows[i].Substring(0, 1) != currentDirection)
                    {
                        Buffer buffer = new Buffer(String_To_Bytes(currentBuffer));
                        BufferNode newNode = new BufferNode(buffer, actors);
                        newNode.Start = text.Length;
                        newNode.BackColor = currentDirection == "I" ? newNode.BackColor = Color.LightCoral : Color.LightBlue;
                        tree.Nodes.Add(newNode);
                        text += currentBuffer;
                        currentBuffer = "";
                        currentDirection = rows[i].Substring(0, 1);
                    }

                    if (currentDirection == "") currentDirection = rows[i].Substring(0, 1);
                    currentBuffer += (rows[i].Substring(4)).Replace("\r", "");
                }
            }


            input.Text = text;
            ApplyFilter();
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

        private void actors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is MessageNode)
                temp.Text = (e.Node as MessageNode).gameMessage.AsText();
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
            string find = (new Find()).Show();
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

        private void pCapPreparsedDumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
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

        private void rawByteDumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Mooege GS Dump | *.txt";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                LoadDump(File.ReadAllText(ofd.FileName));
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
                } else
                    node.BackColor = Color.White;
        }

        /// <summary>
        /// Underscore actor ids and add their sno name
        /// </summary>
        bool dontrec = false;
        private void temp_TextChanged(object sender, EventArgs e)
        {
            if (dontrec) return;
            dontrec = true;
            //output.Rtf = temp.Rtf;
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

            string[] words = output.Text.Split(new string[] {"0x", " ", "\n"}, StringSplitOptions.RemoveEmptyEntries); // .Split(' ');
            List<string> usedKeys = new List<string>();

            // Bruteforce replacement of snos to their aliases
            if (trySNOAliasesToolStripMenuItem.Checked)
                foreach (string word in words)
                    if (word.Length > 5)
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
                                        output.Rtf = output.Rtf.Replace(word, word + ":" + alias);
                                }
                            }
                        }
                        catch (Exception) { }
                    }
        }

        private void pcapDumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw (new Exception("raistlin promised to do it"));
            // this is how its done... 

            //foreach complete packet

                //Buffer buffer = new Buffer(content of packet);
                //BufferNode newNode = new BufferNode(buffer, actors);
                //newNode.Start = position of first byte of packet in the whole stream... can maybe ommited or set to 0
                //newNode.BackColor = currentDirection == "Incoming" ? newNode.BackColor = Color.LightCoral : Color.LightBlue;
                //tree.Nodes.Add(newNode);
            // endforeach


            //input.Text = raw continous hex data;
            ApplyFilter();
        }


    }
}
