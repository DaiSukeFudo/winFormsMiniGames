using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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

            Road.Road_Paint(sender,e);

            Enemy.Enemy_Paint(sender,e);

            Player.Player_Paint(sender, e);


        }


        private void timer_Tick(object sender, EventArgs e)
        {
            Player.Move();

            Enemy.Move();

            this.Invalidate();
        }

        

    }


}

