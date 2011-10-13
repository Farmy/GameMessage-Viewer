using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mooege.Net.GS.Message;
using System.Drawing;

namespace GameMessageViewer
{
    class MessageNode : TreeNode, HighlightingNode
    {
        public GameMessage gameMessage;
        public int mStart;
        public int mEnd;

        public MessageNode clone()
        {
            return new MessageNode()
            {
                Text = this.Text,
                gameMessage = this.gameMessage,
                mStart = this.mStart,
                mEnd = this.mEnd
            };
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

        /*
        public void MarkAsFound()
        {
            this.Parent.Expand();
            this.Parent.BackColor = Color.Yellow;
            this.BackColor = Color.Yellow;
        }

        public void SetToNormal()
        {
            this.BackColor = Color.White;
        }
         */

        public void Highlight(RichTextBox input, Color color)
        {
            input.SelectionStart = mStart >> 2;
            input.SelectionLength = ((mEnd - mStart) % 4) == 0 ? (mEnd - mStart) >> 2 : ((mEnd - mStart) >> 2) + 1;
            input.SelectionBackColor = color;
        }
    }
}
