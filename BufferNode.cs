using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mooege.Net.GS.Message;
using Mooege.Net.GS.Message.Definitions.ACD;
using System.Drawing;
using System.IO;
using Mooege.Net.GS.Message.Definitions.Misc;

namespace GameMessageViewer
{
    class BufferNode : TreeNode, HighlightingNode
    {
        static Dictionary<string, string> SNOAliases;

        static BufferNode()
        {
            SNOAliases = new Dictionary<string, string>();

            try
            {
                foreach (string filename in new string[] { "Actors.txt", "Mobs.txt", "Powers.txt", "Scenes.txt" })
                    foreach (string entry in File.ReadAllLines(filename))
                        if(SNOAliases.ContainsKey(entry.Split(' ')[0]) == false)
                            SNOAliases.Add(entry.Split(' ')[0], entry.Split(' ')[1]);
            }
            catch (Exception) { System.Diagnostics.Debugger.Break(); }
        }



        public Buffer Buffer;
        public int Start;
        private bool expanded = false;
        private TreeView actors;
        private List<MessageNode> allNodes = new List<MessageNode>();

        public void ApplyFilter(Dictionary<string, bool> filter)
        {
            Nodes.Clear();

            foreach(MessageNode node in allNodes)
                if(filter[node.gameMessage.ToString().Split('.').Last()])
                    Nodes.Add(node);
        }

        public BufferNode(Buffer buffer, TreeView actors)
        {
            this.Buffer = buffer;
            this.actors = actors;

            Nodes.Add(new TreeNode());

            if (Buffer.IsPacketAvailable())
            {
                int end = Buffer.Position;
                end += Buffer.ReadInt(32) * 8;

                if ((end - Buffer.Position) >= 9)

                    try
                    {
                        GameMessage message = Buffer.ParseMessage();
                        if (message != null)
                        {
                            Text = message.ToString() + ":" + buffer.Length;
                            buffer.Position = 0;
                        }
                        else
                        {
                            buffer.Position = 32;
                            Text = "Message not implemented: " + Buffer.ReadInt(9);
                            buffer.Position = 0;
                        }

                    }
                    catch (Exception)
                    {
                        Text = "Error parsing node";
                        buffer.Position = 0;
                    }
            }
            else
                Text = "No Packet available";

            Parse();
        }

        public void Parse()
        {
            if (expanded)
                return;
            else
                expanded = true;
            allNodes.Clear();

            while (Buffer.IsPacketAvailable())
            {
                int end = Buffer.Position;
                end += Buffer.ReadInt(32) * 8;
                if (end < Buffer.Position) break;

                while ((end - Buffer.Position) >= 9)
                {
                    try
                    {
                        int start = Buffer.Position;
                        GameMessage message = Buffer.ParseMessage();
                        if (message != null)
                        {

                            if (message is ACDEnterKnownMessage)
                            {
                                String hex = (message as ACDEnterKnownMessage).ActorID.ToString("X8");


                                string name;
                                SNOAliases.TryGetValue((message as ACDEnterKnownMessage).ActorSNO.ToString(), out name);

                                if (!actors.Nodes.ContainsKey(hex))
                                {
                                    TreeNode actorNode = actors.Nodes.Add(hex, hex + "   " + name);
                                    actorNode.Tag = hex;
                                }
                            }


                            MessageNode node = new MessageNode()
                            {
                                Text = message.GetType().ToString(),
                                gameMessage = message,
                                mStart = Start * 4 + start,
                                mEnd = Start * 4 + Buffer.Position
                            };
                            node.BackColor = this.BackColor;

                            string text = message.AsText();
                            foreach (TreeNode an in actors.Nodes)
                                if (text.Contains((string)an.Tag))
                                {
                                    MessageNode nodeb = new MessageNode()
                                    {
                                        Text = message.GetType().ToString(),
                                        gameMessage = message,
                                        mStart = Start * 4 + start,
                                        mEnd = Start * 4 + Buffer.Position
                                    };
                                    nodeb.BackColor = this.BackColor;
                                    an.Nodes.Add(nodeb);
                                }

                            allNodes.Add(node);

                        }
                        else
                        {
                            Buffer.Position -= 9;
                            allNodes.Add(new MessageNode() { Text = "Message not implemented:" + Buffer.ReadInt(9), gameMessage = new BoolDataMessage() });
                            Buffer.Position += 9;
                        }
                    }
                    catch (Exception e)
                    {
                        allNodes.Add(new MessageNode() { Text = "Error parsing :" + e.ToString(), gameMessage = new BoolDataMessage() });
                    }
                }

                Buffer.Position = end;
            }
        }


        public void Highlight(RichTextBox input)
        {
            input.SelectionStart = Start;
            input.SelectionLength = Buffer.Length % 4 == 0 ? Buffer.Length >> 2 : (Buffer.Length >> 2) + 1;
            input.SelectionBackColor = this.BackColor;
            
            foreach (HighlightingNode node in Nodes)
                node.Highlight(input, Color.LightGreen);

        }

        public void Unhighlight(RichTextBox input)
        {
            input.SelectionStart = Start;
            input.SelectionLength = Buffer.Length % 4 == 0 ? Buffer.Length >> 2 : (Buffer.Length >> 2) + 1;
            input.SelectionBackColor = Color.White;
        }

        public void Highlight(RichTextBox input, Color color)
        {
            throw new NotImplementedException();
        }
    }
}
