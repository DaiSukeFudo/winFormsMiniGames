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
using static Game.Player;

namespace Game
{
 
    public partial class Race : Form
    {
        
        private int phon_speed = 10;
        private int enemy_speed = 15;
        private int bitoc_speed = 10;


        private int start_enemy_x = 120;
        private int start_enemy_y = -100;


        public Race()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Size = new Size(600, 600);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Player._KeyDown(sender, e);
        }

         
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Player._KeyUp(sender, e);
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.road, 0, 0);
            e.Graphics.DrawImage(Properties.Resources.road, 0, 0, this.Size.Width, this.Size.Height);
            e.Graphics.DrawImage(Properties.Resources.car, Player.GetX(), Player.GetY(), 128, 128);
            e.Graphics.DrawImage(Properties.Resources.enemy, start_enemy_x, start_enemy_y, 100, 100);
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            Player.Move();
            
            Random random = new Random();

            start_enemy_y += enemy_speed; 

            if (start_enemy_y > this.Height) 
            {
                start_enemy_y = -200;
                start_enemy_x = random.Next(110, 365);
            }
            this.Invalidate();
        }

        
                
    }


}

