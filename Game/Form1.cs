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
 
    public partial class Form1 : Form
    {
        private bool Up = false;
        private bool Down = false;
        private bool isLeft = false;
        private bool isRight = false;

        private int car_speed = 10;
        private int phon_speed = 10;
        private int enemy_speed = 12;
        private int bitoc_speed = 10;


        private int start_pos_x = 200;
        private int start_pos_y = 400;



        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyPreview = true;
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: isLeft = true; break;
                case Keys.D: isRight = true; break;
                case Keys.W: Up = true; break;
                case Keys.S: Down = true; break;
            }
        }

        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: isLeft = false; break;
                case Keys.D: isRight = false; break;
                case Keys.W: Up = false; break;
                case Keys.S: Down = false; break;
            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.road, 0, 0);
            e.Graphics.DrawImage(Properties.Resources.car, start_pos_x, start_pos_y, 128, 128);
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (isLeft && start_pos_x > 165)
            {
                start_pos_x -= car_speed;
                this.Invalidate();
            }
            if (isRight && start_pos_x < 675)
            {
                start_pos_x += car_speed;
                this.Invalidate();
            }
            if (Up && start_pos_y > 150)
            {
                start_pos_y -= car_speed;
                this.Invalidate();
            }
            if (Down && start_pos_y < 440)
            {
                start_pos_y += car_speed;
                this.Invalidate();
            }

        }
    }
}
