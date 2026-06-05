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
        
        private static int x = 400;
        private static int y = 0;

    
        private static int start_y = y - 900;


        private static int Speed = 30; 
        

        public static void Road_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetClip(e.ClipRectangle);
            e.Graphics.DrawImage(Properties.Resources.road, x, y, 800, 900);
            e.Graphics.DrawImage(Properties.Resources.road, x, start_y, 800, 900);
            e.Graphics.ResetClip();

        }
        public static void Move()
        {
            y += Speed;
            start_y += Speed;

            if (y >= 900)
                y = -900;
             
            if (start_y >= 900)
                start_y = -900;
            
        }

        public static void Reset()
        {
            y = 0;
            start_y = -900;
            Speed = 30;
        }

    }
}
