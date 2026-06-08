using System;
using System.Windows.Forms;

namespace Game
{
    public partial class Main_Menu : Form
    {


        public Main_Menu()
        {

            InitializeComponent();
            this.DoubleBuffered = true;
            Sound.music();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Race f2 = new Race(this);
            this.Hide();
            f2.ShowDialog();
            this.Show();

            
            

            
            
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



        private void button1_Click_1(object sender, EventArgs e)
        {
            using (Settings settings = new Settings())
            {
                this.Hide();
                settings.ShowDialog();
                this.Show();
            }
        }
    }
}