using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Game
{
    public partial class Games : Form
    {
        public Games()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sound.RemoveMenuMusic();
            Hide();
            using (TicTacToeGame.TicTacToe gameForm = new TicTacToeGame.TicTacToe())
            {
                gameForm.ShowDialog();
            }
            Show();
            Sound.CreateMenuMusic();
            Sound.PlayMenuMusic();
            //Debug.WriteLine("Main_Menu: race closed");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sound.RemoveMenuMusic();
            Hide();
            using (Race gameForm = new Race())
            {
                gameForm.ShowDialog();
            }
            Show();
            Sound.CreateMenuMusic();
            Sound.PlayMenuMusic();
            //Debug.WriteLine("Main_Menu: race closed");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sound.RemoveMenuMusic();
            Hide();
            using (Snake gameForm = new Snake())
            {
                gameForm.ShowDialog();
            }
            Show();
            Sound.CreateMenuMusic();
            Sound.PlayMenuMusic();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sound.RemoveMenuMusic();
            Hide();
            using (Tetris gameForm = new Tetris())
            {
                gameForm.ShowDialog();
            }
            Show();
            Sound.CreateMenuMusic();
            Sound.PlayMenuMusic();
        }
    }
}
