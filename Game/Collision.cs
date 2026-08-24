using System;
using System.Drawing;
using System.Windows.Forms;


namespace Game
{
    internal class Collision
    {
        public static bool CollisionDetection(Rectangle hitbox1, Rectangle hitbox2)
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
    }
}
