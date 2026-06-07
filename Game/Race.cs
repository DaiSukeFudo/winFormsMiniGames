using System;
using System.Windows.Forms;
using static Game.Collision;



namespace Game
{
 
    public partial class Race : Form
    {
        public Race()
        {
            InitializeComponent();
         
            this.DoubleBuffered = true;
            this.KeyPreview = true;
     
            Bitcoin.CreateBitcoinCounter(this);
            
            Initialize(this);
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
            if (Collision_Detection(Player.GetRect(), Enemy.GetRect()))
            {
                StopGame();

                Sound.PlayExplosionWithStopMusic();
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