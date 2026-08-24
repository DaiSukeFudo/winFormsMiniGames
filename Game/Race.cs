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
        private Label distanceUI;
        private Label bitcoinUI = UIControl.CreateText("bitcoin: 0", new Point(0,5));

        public Race()
        {
            InitializeComponent();

            DoubleBuffered = true;
            KeyPreview = true;

            distanceUI = new Label();
            distanceUI.Font = new Font("Arial", 14);
            distanceUI.ForeColor = Color.GreenYellow;
            distanceUI.AutoSize = true;
            distanceUI.Enabled = true;
            distanceUI.Location = new Point(0, 30);
            distanceUI.Text = $"score: {distanceScore / 5}";
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
            Bitcoin.Reset();   
            Bonuses.Reset();
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
                    Sound.PlayExplosion();

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
                    Sound.PlayExplosion();     
                }
            }

            if (CollisionDetection(Player.GetRect(), Bitcoin.GetRect()))
            {
                Bitcoin.Collect();
            }

            Road.Move();
            Player.Move();
            Enemy.Move();
            Bitcoin.Move();
            Bonuses.Move();

            Invalidate();
        }
        

        private void button1_Click(object sender, EventArgs e)
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