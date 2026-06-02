using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;


namespace Game
{
    //class DoubleBufferedPictureBox : PictureBox
    //{
    //    public DoubleBufferedPictureBox()
    //    {
    //        this.DoubleBuffered = true;
    //    }
    //}
   
    public partial class Form1 : Form
    {
        private bool Up = false;
        private bool Down = false;
        private bool Left = false;
        private bool Right = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            int speed = 15;
            Phon1.Top += speed;
            Phon2.Top += speed;

            int carSpeed = 12;
            Sop1.Top += carSpeed;
            Sop2.Top += carSpeed;
            
            int bitoc_speed = 15;
            bitoc.Top += bitoc_speed;

            if(bitoc.Top >= 600)
            {
                bitoc.Top = -200;
                Random random = new Random();
                bitoc.Left = random.Next(180,600);
            }
            //
            if (Phon1.Top >= 600)
            {
                Phon1.Top = 0;
                Phon2.Top = -600;
            }

            //
            if (Sop1.Top >= 600)
            {
                Sop1.Top = -200;
                Random random = new Random();
                Sop1.Left = random.Next(180, 330);
            }

            //
            if (Sop2.Top >= 600)
            {
                Sop2.Top = -400;
                Random random = new Random();
                Sop2.Left = random.Next(420, 580);
            }
            if (Car.Bounds.IntersectsWith(Sop1.Bounds) || Car.Bounds.IntersectsWith(Sop2.Bounds))
            {
                timer.Enabled = false;
                MessageBox.Show("Вы проиграли");
                this.Close();
            }

            if(Left && Car.Left > 165) { Car.Left -= speed; }
            if (Right && Car.Right < 675) { Car.Left += speed; }
            if (Up && Car.Top > 150) { Car.Top -= speed; }
            if (Down && Car.Top < 440) { Car.Top += speed; }

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: Left = true; break;
                case Keys.D: Right = true; break;
                case Keys.W: Up = true; break;
                case Keys.S: Down = true; break;
            }
        }

        

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: Left = false; break;
                case Keys.D: Right = false; break;
                case Keys.W: Up = false; break;
                case Keys.S: Down = false; break;
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
