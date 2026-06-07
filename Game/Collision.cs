using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Game.Collision;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Game
{
    internal class Collision
    {
        private static Timer timer = new Timer();

        //private static bool isColliding = false;
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



        //public static class GameStats
        //{
        //    public static int BitcoinCount { get; set; } = 0;
        //}




        //public static void Collecting_Bitcoin()
        //{
            
        //    Rectangle playerRect = Player.GetRect();
        //    Rectangle bitcoinRect = Bitcoin.GetRect();

        //    if (playerRect.IntersectsWith(bitcoinRect))
        //    {
                    
        //         GameStats.BitcoinCount++;
      
        //         Bitcoin.Collect();

                    
        //         UpdateBitcoinCounter();
            
        //         Bitcoin.Respawn();
        //    }
            
        //}


        public static void Initialize(Race form)
        {
            raceForm = form;
        }


        //private static void UpdateBitcoinCounter()
        //{
        //    if (raceForm != null)
        //    {
        //        raceForm.UpdateBitcoinLabel(GameStats.BitcoinCount);
        //    }
        //}

    }
}
