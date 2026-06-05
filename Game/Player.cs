using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    internal class Player
    {
        private static bool Up = false;
        private static bool Down = false;
        private static bool isLeft = false;
        private static bool isRight = false;

        private static int x = 800;
        private static int y = 720;

        private static int car_speed = 20;

        private const int Allowance_Left = 550;
        private const int Allowance_Right = 950;
        private const int Allowance_Up = 100;
        private const int Allowance_Down = 720;

        private static Random rnd = new Random();


        private static Rectangle rect;

        public static Rectangle GetRect()
        {
            rect = new Rectangle(x, y, 128, 128);
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

        public static void _KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.A: isLeft = true; break;
                case Keys.D: isRight = true; break;
                case Keys.W: Up = true; break;
                case Keys.S: Down = true; break;
            }
        }

        public static void _KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: isLeft = false; break;
                case Keys.D: isRight = false; break;
                case Keys.W: Up = false; break;
                case Keys.S: Down = false; break;
            }
        }

        
        public static void Move()
        {
            if (isLeft && x > Allowance_Left) 
                x -= car_speed;
 
            if (isRight && x < Allowance_Right)
                x += car_speed;
            
            if (Up && y > Allowance_Up)
                y -= car_speed;
    
            if (Down && y < Allowance_Down)
                y += car_speed;

            rect = new Rectangle(x, y, 128, 128);
        }

        public static void Player_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.car, Player.GetX(), Player.GetY(), 128, 128);
        }


        public static void Reset()
        {
            x = 800;
            y = 720;
            isLeft = false;
            isRight = false;
            Up = false;
            Down = false;
            rect = new Rectangle(x, y, 128, 128);
        }

    }
}
