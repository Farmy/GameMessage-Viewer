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
using System.Reflection;


namespace GameMessageViewer
{
    public partial class CustomLinqQuery : Form
    {
        List<MessageNode> mNodes = new List<MessageNode>();
        List<BufferNode> bNodes = new List<BufferNode>();
        public IEnumerable<MessageNode> QueryResult = new List<MessageNode>();

        public CustomLinqQuery()
        {
            InitializeComponent();
        }

        class cboEntry
        {
            public Type type;
            public cboEntry(Type type) { this.type = type; }
            public override string ToString() { return type.Name; }
        }

        internal DialogResult Show(IEnumerable<BufferNode> nodes)
        {
            // Gather all Types in the AppDomain that inherit from GameMessage
            List<cboEntry> items = new List<cboEntry>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                foreach (Type type in assembly.GetTypes())
                    if (type.BaseType == typeof(GameMessage))
                        items.Add(new cboEntry(type));

            // show them in a combobox
            var sorted = items.OrderBy(x => x.ToString());
            foreach (cboEntry message in sorted)
                comboBox1.Items.Add(message);

            // Create a List of only MessageNodes
            foreach (BufferNode bn in nodes)
                foreach (MessageNode mn in bn.allNodes)
                    mNodes.Add(mn);

            comboBox1.SelectedIndex = 0;
            this.ShowDialog();
            return DialogResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Type genericQuery = typeof(QueryTemplate<>);
            Type concreteQuery = genericQuery.MakeGenericType(((cboEntry)comboBox1.SelectedItem).type);
            object query = Activator.CreateInstance(concreteQuery);


            try
            {
                QueryResult = (IEnumerable<MessageNode>)concreteQuery.GetMethod("Query").Invoke(query, new object[] { mNodes, textBox1.Text });
                QueryResult.Count(); // Force evaluation
            }
            catch (Exception exception)
            {
                lblException.Text = exception.Message;
                return;
            }
            
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }
    }
}
