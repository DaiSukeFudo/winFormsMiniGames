using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

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
            using (Race game_form = new Race())
            {
                this.Hide();
                game_form.ShowDialog();
                this.Show();
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
