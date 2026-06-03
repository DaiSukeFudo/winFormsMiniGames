using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    internal class Enemy
    {
        private static int enemy_speed = 15;

        private static int x = 440;
        private static int y = -100;

        private static Race race1 = new Race();

        private static Random random1 = new Random();

        
        public static int GetX()
        {
            return x;
        }
        public static int GetY()
        {
            return y;
        }
        private Race _race;
        public Enemy(Race race)
        {
            _race = race;
        }
        public static void Move()
        {
            y += enemy_speed;

            if (y > race1.Height)
            {
                y = -200;
                x = random1.Next(440, 1000);
            }
           
        }

        public static void Enemy_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.enemy, Enemy.GetX(), Enemy.GetY(), 100, 100);
        }
    }
}
