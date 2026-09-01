using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    internal class Enemy
    {
        //private static Image enemyImage = Properties.Resources.enemy;
        private static Image enemyImage = Properties.Resources.car;
        private static Random random = new Random();
        private static int enemy_speed = 20;
        private static int x = random.Next(200, 540);
        private static int y = -500;
        
        private static int width = 75;
        private static int height = 75;
        private static Rectangle rect;


        //static Enemy()
        //{
        //    x = random.Next(200, 540);
        //}

        public static Rectangle GetRect()
        {
            rect = new Rectangle(x, y, width, height-75); 
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
            rect = new Rectangle(x, y, width, height-75);
        }


        public static void Enemy_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(enemyImage, x, y, width, -1 * height); //
            
        }


        public static void Reset()
        {
            x = random.Next(200, 540);
            y = -500;
        }
    }
}