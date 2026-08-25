using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class TestRace : Form
    {
        //private Image roadImage;

        public TestRace()
        {
            InitializeComponent();

            //roadImage = new Bitmap(Properties.Resources.road);
        }
        


        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void TestRace_Paint(object sender, PaintEventArgs e)
        {

            //e.Graphics.DrawImage(roadImage, 0, 0, 600, 600);
            //e.Graphics.DrawImage(roadImage, 0, 0, 600, 600);
            //e.Graphics.DrawImage(roadImage, 0, 0, 600, 600);
            //e.Graphics.DrawImage(roadImage, 0, 0, 600, 600);
            //e.Graphics.DrawImage(roadImage, 0, 0, 600, 600);
            //e.Graphics.DrawImage(roadImage, 0, 0, 600, 600);
            //e.Graphics.DrawImage(roadImage, 0, 0, 600, 600);
            //e.Graphics.DrawImage(roadImage, 0, 0, 600, 600);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }



    }

}
