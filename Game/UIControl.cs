using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    internal class UIControl
    {
        public static Label CreateLabel(string text, Point location, Color color)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = location;
            label.Font = new Font("Arial", 14);
            label.ForeColor = color;

            label.BringToFront();
            label.AutoSize = true;
            return label;
        }
    }
}
