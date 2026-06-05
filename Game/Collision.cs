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

        private static bool isColliding = false;
        private static Race raceForm;



        

        public static void Collision_Detection()
        {
            Rectangle playerRect = Player.GetRect();
            Rectangle enemyRect = Enemy.GetRect();

            if (playerRect.IntersectsWith(enemyRect) && !isColliding)
            {
                isColliding = true;
                Race raceForm = null;
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Race)
                    {
                        raceForm = (Race)form;
                        break;
                    }
                }

                if (raceForm != null)
                {
                    timer.Enabled = false;
                }

                DialogResult result = MessageBox.Show("Вы проиграли! Хотите сыграть еще?",
                                                       "Game Over",
                                                       MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    GameStats.BitcoinCount = 0;
                    UpdateBitcoinCounter();
                    Player.Reset();
                    Enemy.Reset();
                    Road.Reset();
                    Bitcoin.Reset();

                    if (raceForm != null)
                    {
                        timer.Enabled = true;
                    }
                }
                else
                {
                    if (raceForm != null)
                    {
                        raceForm.Close();
                    }
                }


            }
            else if (!playerRect.IntersectsWith(enemyRect))
            {
                isColliding = false;
            }
        }

        public static class GameStats
        {
            public static int BitcoinCount { get; set; } = 0;
        }

        public static void Collecting_Bitcoin()
        {
            Rectangle playerRect = Player.GetRect();
            Rectangle bitcoinRect = Bitcoin.GetRect();

            if (playerRect.IntersectsWith(bitcoinRect))
            {
                    
                 GameStats.BitcoinCount++;

                    
                 Bitcoin.Collect();

                    
                 UpdateBitcoinCounter();

                    
                 Bitcoin.Respawn();
            }
            
        }

        public static void Initialize(Race form)
        {
            raceForm = form;
        }

        private static void UpdateBitcoinCounter()
        {
            if (raceForm != null)
            {
                raceForm.UpdateBitcoinLabel(GameStats.BitcoinCount);
            }
        }

        


    }
}
