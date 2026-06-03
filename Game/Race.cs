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
 
    public partial class Race : Form
    {
      

       
        
        

        public Race()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Player._KeyDown(sender, e);
        }

         
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Player._KeyUp(sender, e);
        }



        private void Race_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.DrawImage(Properties.Resources.road, 0, 0);
            
            e.Graphics.DrawImage(Properties.Resources.enemy, Enemy.GetX(), Enemy.GetY(), 100, 100);
            e.Graphics.DrawImage(Properties.Resources.car, Player.GetX(), Player.GetY(), 128, 128);

        }


        private void timer_Tick(object sender, EventArgs e)
        {
            Player.Move();

            Enemy.Move();

            this.Invalidate();
        }

        

    }


}

