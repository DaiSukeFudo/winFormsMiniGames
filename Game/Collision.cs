using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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

                    Player.Reset();
                    Enemy.Reset();
                    Road.Reset();

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

    }
}
