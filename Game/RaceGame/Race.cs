using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;



namespace Game
{
    public partial class Race : Form
    {

        private List<IGameObject> gameObjects = new List<IGameObject>();

        private Player player;
        private Enemy enemy1;
        private Enemy enemy2;
        private Bitcoin bitcoin;
        private Bonuses shieldBonus;

        private Label scoreLabel;
        private Label bitcoinLabel;


        private int distanceScore = 0;
        private Random random = new Random();

        public Race()
        {
            InitializeComponent();

            DoubleBuffered = true;

            CreateUI();

            CreateGameObjects();


            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            KeyPreview = true;


            Sound.CreateBitcoinCollect();
            Sound.CreatePlayerExplosion();



            

            timer.Interval = 25;
            timer.Enabled = true;

            this.Paint += new PaintEventHandler(Race_Paint);
        }

        public void StopGame()
        {
            timer.Enabled = false;
        }

        private void RaceFormKeyDown(object sender, KeyEventArgs e)
        {
            player.KeyDown(sender,e);
        }

        private void RaceFormKeyUp(object sender, KeyEventArgs e)
        {
            player.KeyUp(sender, e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Road.Move();

            foreach (var obj in gameObjects)
            {
                obj.Update();
            }

            distanceScore++;
            scoreLabel.Text = $"Score: {distanceScore / 5}";

            CheckCollisions();

            
            bitcoinLabel.Text = $"Bitcoins: {Bitcoin.GetTotalCollected()}";

            Invalidate();

        }
           

        

        private void CreateUI()
        {
            scoreLabel = UIControl.CreateLabel("Score: 0", new Point(0, 5), Color.GreenYellow);
            bitcoinLabel = UIControl.CreateLabel("Bitcoins: 0", new Point(0, 30), Color.Gold);

            Controls.Add(scoreLabel);
            Controls.Add(bitcoinLabel);
        }

        private void CreateGameObjects()
        {
           
            player = new Player(400, 500, 64, 64, Properties.Resources.car);
            gameObjects.Add(player);

           
            enemy1 = new Enemy(
                random.Next(200, 540),
                random.Next(-500, -50),
                50, 50,
                Properties.Resources.enemy,
                15
            );
            gameObjects.Add(enemy1);

            enemy2 = new Enemy(
                random.Next(200, 540),
                random.Next(-500, -50),
                50, 50,
                Properties.Resources.enemy,
                25
            );
            gameObjects.Add(enemy2);

            
            bitcoin = new Bitcoin(
                random.Next(200, 540),
                random.Next(-500, -50),
                64, 32,
                Properties.Resources.bitcoin,
                10
            );
            gameObjects.Add(bitcoin);

            
            shieldBonus = new Bonuses(
                random.Next(200, 540),
                random.Next(-500, -50),
                64, 32,
                Properties.Resources.Shield,
                15
            );
            gameObjects.Add(shieldBonus);
        }

        private void Race_Paint(object sender, PaintEventArgs e)
        {

            Road.Road_Paint(sender, e);

            foreach (var obj in gameObjects)
            {
                obj.Draw(e.Graphics);
            }
        }


        private void Exit_Click(object sender, EventArgs e) 
        {
            if (timer != null) 
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

        private void CheckCollisions()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = i + 1; j < gameObjects.Count; j++)
                {
                    var objA = gameObjects[i];
                    var objB = gameObjects[j];

                    if (!objA.GetBounds().IntersectsWith(objB.GetBounds()))
                        continue;

                    if (objA is Player && objB is Enemy)
                    {
                        bool isDead = player.TakeDamage();
                        if (isDead) GameOver();
                    }
                    else if (objA is Enemy && objB is Player)
                    {
                        bool isDead = player.TakeDamage();
                        if (isDead) GameOver();
                    }

                    if (objA is Player && objB is Bitcoin)
                    {
                        bitcoin.Collect();
                    }
                    else if (objA is Bitcoin && objB is Player)
                    {
                        bitcoin.Collect();
                    }

                    if (objA is Player && objB is Bonuses)
                    {
                        shieldBonus.Collect(player);
                    }
                    else if (objA is Bonuses && objB is Player)
                    {
                        shieldBonus.Collect(player);
                    }
                }
            }
        }

        private void GameOver()
        {
            timer.Enabled = false;

            DialogResult result = MessageBox.Show(
                "Вы проиграли! Хотите сыграть ещё?",
                "Game Over",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else
            {
                Close();
            }
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

        public void RestartGame()
        {
            Road.Reset();
            player.Reset();
            enemy1.Reset();
            enemy2.Reset();
            bitcoin.Reset();
            shieldBonus.Reset();

            distanceScore = 0;
            timer.Enabled = true;
        }

    }
}