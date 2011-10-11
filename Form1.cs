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

        public MessageViewer()
        {
            InitializeComponent();
        }

        String[] rawinput;

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
            if (tree.SelectedNode is BufferNode)
                (tree.SelectedNode as BufferNode).Parse();

            if(tree.SelectedNode is MessageNode)
                output.Text = (tree.SelectedNode as MessageNode).gameMessage.AsText();

            //(tree.SelectedNode as HighlightingNode).Highlight(input);
        }


        private void input_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {

                rawinput = input.Text.Split('\n');
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
                output.Text = (e.Node as MessageNode).gameMessage.AsText();
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
    }
}
