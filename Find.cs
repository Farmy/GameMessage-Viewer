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
    public partial class Find : Form
    {
        public Find()
        {
            InitializeComponent();

            List<String> items = new List<string>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                foreach (Type type in assembly.GetTypes())
                    if (type.BaseType == typeof(GameMessage))
                        items.Add(type.Name);

            items.Sort();
            foreach(String message in items)
                cboMessages.Items.Add(message);
        }

        public new string Show()
        {
            this.ShowDialog();
            return cboMessages.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Find_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }
    }
}
