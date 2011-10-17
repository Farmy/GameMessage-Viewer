using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mooege.Net.GS.Message;
using System.Drawing;

namespace GameMessageViewer
{
    public class MessageNode : TreeNode, HighlightingNode
    {
        public GameMessage gameMessage;
        public int mStart;
        public int mEnd;

        public MessageNode(GameMessage message, int start, int end)
        {
            this.gameMessage = message;
            this.mStart = start;
            this.mEnd = end;
            Text = String.Join(".", (message.GetType().ToString().Split('.').Skip(5)));
        }

        public new MessageNode Clone()
        {
            return new MessageNode(gameMessage, mStart, mEnd);
        }

        public void Highlight(RichTextBox r)
        {
            this.BackColor = Color.Yellow;
            Highlight(r, Color.Green);
        }

        public void Unhighlight(RichTextBox r)
        {
            this.BackColor = Color.White;
            (Parent as HighlightingNode).Highlight(r);
        }

        public void Highlight(RichTextBox input, Color color)
        {
            input.SelectionStart = mStart >> 2;
            input.SelectionLength = ((mEnd - mStart) % 4) == 0 ? (mEnd - mStart) >> 2 : ((mEnd - mStart) >> 2) + 1;
            input.SelectionBackColor = color;
        }
    }
}
