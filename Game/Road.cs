using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Game
{
    internal class Road
    {
        private static Race race = new Race();
        private static float scaleY;
        private static int newWidth;
        private static int newHeight;
        private static int x;
        private static int y;

        public static void Road_Paint(object sender, PaintEventArgs e)
        {
            scaleY = (float)race.ClientSize.Height / Properties.Resources.road.Height;
            newWidth = (int)(Properties.Resources.road.Width * scaleY);
            newHeight = race.ClientSize.Height;
            x = (race.ClientSize.Width - newWidth) / 2; 
            y = 0;
            Rectangle destRect = new Rectangle(x, y, newWidth, newHeight);
            e.Graphics.DrawImage(Properties.Resources.road, destRect);
        }
    }
}
