using System;
using System.Drawing;
using System.Windows.Forms;


namespace Game
{
    internal class Collision
    {
        private static Timer timer = new Timer();

        private static Race raceForm;


        public static bool Collision_Detection(Rectangle hitbox1, Rectangle hitbox2)
        {
            if (hitbox1.IntersectsWith(hitbox2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Initialize(Race form)
        {
            raceForm = form;
        }

    }
}
