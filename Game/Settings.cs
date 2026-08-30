using System;
using System.Windows.Forms;

namespace Game
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(cbMainMenuMusic.Checked)
            {
                Properties.Settings.Default.SoundStatus = true;
                Sound.CreateMenuMusic();
                Sound.PlayMenuMusic();
            }
            else
            {
                Sound.RemoveMenuMusic();
                Properties.Settings.Default.SoundStatus = false;
            }
        }
    }
}
