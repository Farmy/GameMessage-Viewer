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

        public void Highlight(RichTextBox r)
        {
            Highlight(r, Color.Green);
        }

        public void Unhighlight(RichTextBox r)
        {
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
