using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace GameMessageViewer
{
    public partial class MessageViewer : Form
    {
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


        private void LoadWiresharkHex(string text)
        {
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
                        BufferNode newNode = new BufferNode(buffer, actors, questTree);
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
                BufferNode newNode = new BufferNode(buffer, actors, questTree);
                newNode.Parse();
                tree.Nodes.Add(newNode);
            }

            input.Text = text;

            ApplyFilter();
        }


        /// <summary>
        /// Pcap loading extracts the largest session from a pcap, transforms it to dump format (in a memory stream)
        /// which can be read by LoadDump afterwards
        /// </summary>
        /// <param name="path"></param>
        private void LoadPcap(string path)
        {
            try
            {
                // This ugly thing returns a list of MemoryStreams. One for each session in the cap
                var streams = pCapReader.ReconSingleFileSharpPcap(path);

                // Take the largest session (yeah if its no working for you, this may cause it)
                var ordered = streams.OrderBy(stream => stream.Length);
                ordered.Last().Seek(0, SeekOrigin.Begin);
                LoadDump(new StreamReader(ordered.Last()).ReadToEnd());
            }
            catch (SharpPcap.PcapException) {
                MessageBox.Show("The file could not be read. Only lipcap cap files can be loaded. If you want to load a NetMon cap the README tells you how to", "Loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadDump(string text)
        {
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
                        BufferNode newNode = new BufferNode(buffer, actors, questTree);
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
    }
}
