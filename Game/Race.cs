using System;
using System.Drawing;
using System.Windows.Forms;
using static Game.Collision;



namespace Game
{
 
    public partial class Race : Form
    {
        private static int distance = 0;
        private static Label distUI;

        private static Form main_menu;
      
        public Race(Form mm)
        {
            InitializeComponent();

            System.Diagnostics.Debug.WriteLine("Race init");
            main_menu = mm;
            DoubleBuffered = true;
            KeyPreview = true;

            distUI = new Label();
            distUI.Font = new Font("Arial", 14);
            distUI.ForeColor = Color.GreenYellow;
            distUI.AutoSize= true;
            distUI.Enabled=true;
            distUI.Location = new Point(0, 30);
           
            Bitcoin.CreateBitcoinCounter(this);

            Controls.Add(distUI);
            distUI.Text = $"score: {distance / 5}";

            timer.Interval = 25;
            Initialize(this);

            
        }

        public static int GetDistance()
        {
            return distance;
        }

        public void RestartGame()
        {
            timer.Enabled = false;
            distance = 0;
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
            
            distance++;
            
            distUI.Text = $"score: {distance / 5}";
            distUI.Update();
          



            if (CollisionDetection(Player.GetRect(), Enemy.GetRect()))
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
                    RestartGame();
                    main_menu.Show();
                    Close();
                    return;
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


            Invalidate();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

       

    }
}