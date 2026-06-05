using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    internal class Bitcoin
    {
        private static Random random = new Random();
        private static int bitok_speed = 20;
        private static bool isActive = true;

        private static int x = 600;
        private static int y = -100;
        private static Rectangle rect;

        public static Rectangle GetRect()
        {
            rect = new Rectangle(x, y, 60, 60);
            return rect;
        }

        public static void Move()
        {
           y += bitok_speed;

           if (y > 900)
           {
               Respawn();
           }
           rect = new Rectangle(x, y, 60, 60);
        }

        public static void Respawn()
        {
            isActive = true;
            y = random.Next(-500, -50); 
            x = random.Next(550, 950);   
            
        }

        public static void Collect()
        {
            isActive = false;
        }

 
        public static int GetX()
        {
            return x;
        }

        
        public static int GetY()
        {
            return y;
        }


        public static void Bitok_Print(object sender, PaintEventArgs e)
        {
                e.Graphics.DrawImage(Properties.Resources.bitcoin, x, y, 60, 60);
        }


        public static void Reset()
        {
            isActive = true;
            x = random.Next(550, 950);
            y = random.Next(-500, -50);
            bitok_speed = 20;
        }
    }
}
