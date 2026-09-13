using System.Drawing;
using System.Windows.Forms;


namespace Game
{
    internal class Road
    {
        private static Image roadImage = Properties.Resources.road;
        private static int x = 50;
        private static int y = 0;
        private static int start_y = y - 600;
        private static int Speed = 10; 
        

        public static void Road_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetClip(e.ClipRectangle);
            e.Graphics.DrawImage(roadImage, x, y, 700, 600);
            e.Graphics.DrawImage(roadImage, x, start_y, 700, 600);
            e.Graphics.ResetClip();
        }


        public static void Move()
        {
            y += Speed;
            start_y += Speed;

            if (y >= 600)
            {
                y = -600;
            }
            if (start_y >= 600)
            {
                start_y = -600;
            }            
        }


        public static void Reset()
        {
            y = 0;
            start_y = -600;
        }
    }
}
