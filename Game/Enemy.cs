using System;
//using System.Collections.Generic;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    internal class Enemy
    {
        private static int enemy_speed = 20;

        private static int x = 400;
        private static int y = -100;

        

        private static Random random1 = new Random();


        private static int width = 64;
        private static int height = 64;
        private static Rectangle rect;

        public static Rectangle GetRect()
        {
            rect = new Rectangle(x, y, width, height); 
            return rect;
        }


        public static int GetX()
        {
            return x;
        }

        public static int GetY()
        {
            return y;
        }

        public static void Move()
        {
            y += enemy_speed;

            if (y > 600)
            {
                y = -200;
                x = random1.Next(220, 520);
            }
            rect = new Rectangle(x, y, width, height);
        }

        public static void Enemy_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.enemy, Enemy.GetX(), Enemy.GetY(), width + 10, height + 10);
        }


        public static void Reset()
        {
            x = 400;
            y = -100;
            //rect = new Rectangle(x, y, 100, 100);
        }

    }
}
