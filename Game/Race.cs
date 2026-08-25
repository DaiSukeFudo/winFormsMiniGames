using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static Game.Collision;


namespace Game
{
    public partial class Race : Form
    {
        private int distanceScore = 0;

        private Label distanceUI = UIControl.CreateLabel("score: 0", new Point(0, 5), Color.GreenYellow);
        private Label bitcoinUI = UIControl.CreateLabel("bitcoin: 0", new Point(0, 30), Color.Gold);

        public Race()
        {
            InitializeComponent();

            DoubleBuffered = true;
            KeyPreview = true;

            Controls.Add(distanceUI);
            Controls.Add(bitcoinUI);

            timer.Interval = 25;

            Debug.WriteLine("Race init");
        }


        public void RestartGame()
        {
            timer.Enabled = false;
            distanceScore = 0;
            Road.Reset();
            Player.Reset();
            Enemy.Reset();
            Bitcoin.Reset(bitcoinUI);   
            Bonuses.Reset();
            timer.Enabled = true;
        }


        public void StopGame()
        {
            timer.Enabled = false;
        }


        private void RaceFormKeyDown(object sender, KeyEventArgs e)
        {
            Player.PlayerKeyDown(sender, e);
        }


        private void RaceFormKeyUp(object sender, KeyEventArgs e)
        {
            Player.PlayerKeyUp(sender, e);
        }
        

        private void Race_Paint(object sender, PaintEventArgs e)
        {
            Road.Road_Paint(sender, e);
            Bitcoin.Bitcoin_Paint(sender, e);
            Enemy.Enemy_Paint(sender, e);
            Player.Player_Paint(sender, e);
            Bonuses.Bonuses_Paint(sender, e);
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed || this.Disposing)
            {
                return;
            }

            distanceScore++;

            distanceUI.Text = $"score: {distanceScore / 5}";
            distanceUI.Update();


            if (CollisionDetection(Player.GetRect(), Enemy.GetRect()))
            {
                bool isDead = Player.LoseLife();

                if (isDead)
                {
                    StopGame();
                    Sound.PlayPlayerExplosion(); // PROBLEM

                    DialogResult result = MessageBox.Show("Вы проиграли! Хотите сыграть еще?",
                                                           "Game Over",
                                                           MessageBoxButtons.YesNo
                    );

                    if (result == DialogResult.Yes)
                    {
                        RestartGame();
                    }
                    else
                    {
                        RestartGame();
                        Close();
                        Sound.PlayMenuMusic();
                        return;
                    }
                }
                else
                {     
                    Sound.PlayPlayerExplosion();     
                }
            }

            if (CollisionDetection(Player.GetRect(), Bitcoin.GetRect()))
            {
                Bitcoin.Collect(bitcoinUI);
            }

            Road.Move();
            Player.Move();
            Enemy.Move();
            Bitcoin.Move();
            Bonuses.Move();

            Invalidate();
        }
        

        private void Exit_Click(object sender, EventArgs e) // PROBLEM: memory leak!!!
        {

            if (timer != null)
            {
                timer.Enabled = false; // Выключаем
                timer.Dispose();       // Полностью удаляем таймер из памяти
            }
            RestartGame();
            Dispose();
            Sound.PlayMenuMusic();
            Debug.WriteLine("BUTTON: exit");
        }
    }
}