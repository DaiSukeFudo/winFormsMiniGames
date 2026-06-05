using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Math;


namespace Game
{
 
    public partial class Race : Form
    {
        private static Timer gameTimer;
        private Label bitcoinCounterLabel;
        public Race()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            timer.Interval = 33;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            this.DoubleBuffered = true;
            this.KeyPreview = true;
            gameTimer = timer;

            
            CreateBitcoinCounter();

            
            Collision.Initialize(this);

            
            Collision.GameStats.BitcoinCount = 0;
            UpdateBitcoinLabel(0);
        }


        private void CreateBitcoinCounter()
        {
            bitcoinCounterLabel = new Label();
            bitcoinCounterLabel.Text = "Монетки: 0";
            bitcoinCounterLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            bitcoinCounterLabel.ForeColor = Color.Gold;
            bitcoinCounterLabel.BackColor = Color.Transparent;
            bitcoinCounterLabel.Size = new Size(150, 40);
            bitcoinCounterLabel.Location = new Point(10, 10);
            bitcoinCounterLabel.Parent = this;
            bitcoinCounterLabel.BringToFront();
            this.Controls.Add(bitcoinCounterLabel);
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
            Road.Move();
            Player.Move();
            Enemy.Move();
            Bitcoin.Move();
            Collision.Collision_Detection();
            Collision.Collecting_Bitcoin();

            this.Invalidate();     
        }
    }
}

