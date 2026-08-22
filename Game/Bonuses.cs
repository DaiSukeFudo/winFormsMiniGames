using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    internal class Bonuses
    {
        private static Image shieldImage = Properties.Resources.Shield;

        private static Random random = new Random();
        private static int x;
        private static int y = -600;

        private static int speed = 15;

        Bonuses()
        {
            x =  random.Next(200 , 540);
        }


        private static int width = 64;
        private static int height = 32;

        private static Rectangle rect;

        



        public static void Move()
        {

            y += speed;




            if (y > 600)
            {
                y = -height;
                x = random.Next(200, 540);
            }
            rect = new Rectangle(x, y, width, height);
        }

        public static void Bonuses_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(shieldImage, x, y, width, height);

        }


        public static void Reset()
        {
            x = random.Next(200, 540);
            y = -500;
        }

    }
}

