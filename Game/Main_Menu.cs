using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Game
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Sound.PlayMenuMusic();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Sound.StopMenuMusic();
            Hide();
            using (Race gameForm = new Race())
            {
                gameForm.ShowDialog();
            }   
            Show();
            Debug.WriteLine("Race: closed");
        }


        private void button1_Click_1(object sender, EventArgs e)
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
            e.Graphics.DrawImage(Properties.Resources.background, 0, 0, this.Size.Width, this.Size.Height);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

    }
}