using System;
using System.Collections.Generic;
using System.Linq;
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

        private static int x = 200;
        private static int y = 400;

        private static int car_speed = 15;

        private const int Allowance_Left = 110;
        private const int Allowance_Right = 365;
        private const int Allowance_Up = 150;
        private const int Allowance_Down = 440;

        private static Race race = new Race();
       
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
            {
                x -= car_speed;
                race.Invalidate();
            }
            if (isRight && x < Allowance_Right)
            {
                x += car_speed;
                race.Invalidate();
            }
            if (Up && y > Allowance_Up)
            {

                y -= car_speed;
                race.Invalidate();
            }
            if (Down && y < Allowance_Down)
            {
                y += car_speed;
                race.Invalidate();
            }
        }



    }
}
