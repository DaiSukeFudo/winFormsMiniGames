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

        private Label scoreUI = UIControl.CreateLabel("score: 0", new Point(0, 5), Color.GreenYellow);
        private Label bitcoinUI = UIControl.CreateLabel("bitcoin: 0", new Point(0, 30), Color.Gold);

        public Race()
        {
            InitializeComponent();

            DoubleBuffered = true;

            // Дополнительные стили для оптимизации отрисовки
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            KeyPreview = true;


            Sound.CreateBitcoinCollect();
            Sound.CreatePlayerExplosion();


            // Ensure in-form labels are part of the normal paint lifecycle to avoid
            // creating ad-hoc DeviceContexts via Update().
            Controls.Add(scoreUI);
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
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;//
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;//

            Road.Road_Paint(sender, e);
            Bitcoin.Bitcoin_Paint(sender, e);
            Enemy.Enemy_Paint(sender, e);
            Player.Player_Paint(sender, e);
            Bonuses.Bonuses_Paint(sender, e);

        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed || this.Disposing) // IDK
            {
                return;
            }

            distanceScore++;

            scoreUI.Text = $"score: {distanceScore / 5}";
            scoreUI.Update();


            if (CollisionDetection(Player.GetRect(), Enemy.GetRect()))
            {
                bool isDead = Player.LoseLife();

                if (isDead)
                {
                    StopGame();

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
                        if (timer != null) // maybe do func
                        {
                            timer.Enabled = false;
                            timer.Dispose();
                        }
                        RestartGame();
                        Sound.RemovePlayerExplosion();
                        Sound.RemoveBitcoinCollect();
                        ClearAllImages(this.Controls);
                        Dispose();
                    }
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
            if (timer != null) // maybe do func
            {
                timer.Enabled = false;
                timer.Dispose();
            }
            RestartGame();
            Sound.RemovePlayerExplosion();
            Sound.RemoveBitcoinCollect();

            ClearAllImages(this.Controls);
            Dispose();
            //Sound.PlayMenuMusic();
            //Debug.WriteLine("BUTTON: exit");

        }


        private void ClearAllImages(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                // 1. Если элемент — это PictureBox, уничтожаем его картинку
                if (ctrl is PictureBox pb)
                {
                    if (pb.Image != null)
                    {
                        pb.Image.Dispose();
                        pb.Image = null;
                    }
                    if (pb.InitialImage != null) // Очищаем стандартное/загрузочное изображение
                    {
                        pb.InitialImage.Dispose();
                        pb.InitialImage = null;
                    }
                }

                // 2. Если внутри этого элемента есть другие элементы (например, в Panel или GroupBox)
                // запускаем этот же метод для них (рекурсия)
                if (ctrl.HasChildren)
                {
                    ClearAllImages(ctrl.Controls);
                }

                // 3. Дополнительно очищаем фоновые изображения самих контейнеров
                if (ctrl.BackgroundImage != null)
                {
                    ctrl.BackgroundImage.Dispose();
                    ctrl.BackgroundImage = null;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
    }
}