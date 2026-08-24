using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    internal class Enemy
    {
        private static Image enemyImage = Properties.Resources.enemy;
        private static int enemy_speed = 20;
        private static int x;
        private static int y = -500;
        private static Random random = new Random();
        private static int width = 50;
        private static int height = 50;
        private static Rectangle rect;


        public static Rectangle GetRect()
        {
            rect = new Rectangle(x, y, width, height); 
            return rect;
        }

    
        public static void Move()
        {       
            y += enemy_speed;

            if (y > 600)
            {
                y = -height;
                x = random.Next(220, 520);
            }
            rect = new Rectangle(x, y, width, height);
        }


        public static void Enemy_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(enemyImage, x, y, width + 10, height + 10);
            
        }


        public static void Reset()
        {
            x = random.Next(200, 540);
            y = -500;
        }
    }
}