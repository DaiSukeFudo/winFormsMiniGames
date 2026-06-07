using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    internal class Player
    {
        private static Image playerImage = Properties.Resources.car;


        private static int x = 400;
        private static int y = 500;
        private static int car_speed = 15;

        private static bool Up = false;
        private static bool Down = false;
        private static bool isLeft = false;
        private static bool isRight = false;

        private const int Allowance_Left = 200;
        private const int Allowance_Right = 540;
        private const int Allowance_Up = 20;
        private const int Allowance_Down = 530;


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

            rect = new Rectangle(x, y, width, height);
        }

        public static void Player_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(playerImage, Player.GetX(), Player.GetY(), width, height);
        }


        public static void Reset()
        {
            x = 400;
            y = 500;
            isLeft = false;
            isRight = false;
            Up = false;
            Down = false;
        }

    }
}
