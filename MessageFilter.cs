using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Mooege.Net.GS.Message;

namespace GameMessageViewer
{
    public partial class MessageFilter : Form
    {
        public Dictionary<string, bool> Filter = new Dictionary<string, bool>();


        public MessageFilter()
        {
            InitializeComponent();

            List<CheckBox> boxes = new List<CheckBox>();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                foreach (Type type in assembly.GetTypes())
                    if (type.BaseType == typeof(GameMessage))
                    {
                        CheckBox chk = new CheckBox();
                        chk.Tag = type.Name;
                        chk.Text = type.Name;
                        chk.AutoSize = true;
                        boxes.Add(chk);
                    }

            boxes.Sort((a, b) => a.Text.CompareTo(b.Text));

            for (int i = 0; i < boxes.Count; i++)
            {
                checkedListBox1.Items.Add(boxes[i].Text);
            }
        }

        new public void Show()
        {

            this.ShowDialog();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string name = checkedListBox1.Items[i].ToString();
                Filter[name] = checkedListBox1.GetItemChecked(i);
            }
            this.Close();
        }

        private void cmdAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++) {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void cmdNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            } 
        } 
    }
}
