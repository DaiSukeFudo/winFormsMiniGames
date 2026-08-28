using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Game
{
    public partial class Main_Menu : Form
    {
        private static Image backgound = Properties.Resources.background;

        public Main_Menu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Sound.CreateMenuMusic();
            Sound.PlayMenuMusic();

        }


        private void Play_Click(object sender, EventArgs e)
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
            Debug.WriteLine("Main_Menu: race closed");
        }


        private void Settings_Click(object sender, EventArgs e)
        {
            using (Settings gameForm = new Settings())
            {
                gameForm.ShowDialog();
            }
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Main_Menu_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(backgound, 0, 0, this.Size.Width, this.Size.Height);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Server gameForm = new Server())
            {
                gameForm.ShowDialog();
            }
        }
    }
}