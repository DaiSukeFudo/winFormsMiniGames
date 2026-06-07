using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Diagnostics;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Linq;
//using System.Media;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using static Game.Collision;
//using static System.Math;
//using static System.Net.Mime.MediaTypeNames;


namespace Game
{
 
    public partial class Race : Form
    {

        private Label bitcoinCounterLabel;
        public Race()
        {
            InitializeComponent();
         
            this.DoubleBuffered = true;
            this.KeyPreview = true;
     
            Bitcoin.CreateBitcoinCounter(this);
            
            Initialize(this);
     
            //GameStats.BitcoinCount = 0;
            UpdateBitcoinLabel(0);
        }

  
        public void UpdateBitcoinLabel(int count)
        {
            if (bitcoinCounterLabel != null && !bitcoinCounterLabel.IsDisposed)
            {
                if (bitcoinCounterLabel.InvokeRequired)
                {
                    bitcoinCounterLabel.Invoke(new Action(() =>
                        bitcoinCounterLabel.Text = $"Монетки: {count}"));
                }
                else
                {
                    bitcoinCounterLabel.Text = $"Монетки: {count}";
                }
            }
        }


        public void RestartGame()
        {
            Road.Reset();
            Player.Reset();
            Enemy.Reset();
            Bitcoin.Reset();   
            timer.Enabled = true;
        }


        public void StopGame()
        {
            timer.Enabled = false;
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
            Road.Road_Paint(sender, e);
            Bitcoin.Bitok_Print(sender, e);
            Enemy.Enemy_Paint(sender, e);
            Player.Player_Paint(sender, e);
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            //Collecting_Bitcoin();
            
            if (Collision_Detection(Player.GetRect(), Enemy.GetRect()))
            {
                StopGame();
                DialogResult result = MessageBox.Show("Вы проиграли! Хотите сыграть еще?",
                                                       "Game Over",
                                                       MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {   
                    RestartGame();
                }

                else
                {
                    System.Windows.Forms.Application.Restart();
                }
            }


            if (Collision_Detection(Player.GetRect(), Bitcoin.GetRect()))
            {

                Bitcoin.Collect();
            }

            
            Road.Move();
            Player.Move();
            Enemy.Move();
            Bitcoin.Move();

            this.Invalidate();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }
    }
}