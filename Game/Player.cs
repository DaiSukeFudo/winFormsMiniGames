using System;
using System.Drawing;
using System.Windows.Forms;


namespace Game
{
    internal class Player
    {
        private static Image playerImage = Properties.Resources.car;
        private static Image heartImage = Properties.Resources.health;

        private static int x = 400;
        private static int y = 500;
        private static int car_speed = 15;

        private static bool Up = false;
        private static bool Down = false;
        private static bool isLeft = false;
        private static bool isRight = false;

        private const int Allowance_Left = 200;
        private const int Allowance_Right = 540;
        private const int Allowance_Up = 0;
        private const int Allowance_Down = 530;

        private static int width = 64;
        private static int height = 64;
        private static Rectangle rect;

        private static int lives = 3;
        private static int currentLives = lives;

        private static bool isInvincible = false;
        private static Timer invincibilityTimer = new Timer();
        private static int blinkCounter = 0;

        // Reuse a single Font instance for drawing hearts to avoid allocating a new
        // Font on every Paint call (prevents GDI handle growth).
        private static readonly Font heartsFont = new Font("Arial", 14);


        static Player()
        {
            invincibilityTimer.Interval = 100;
            invincibilityTimer.Tick += InvincibilityTimer_Tick;
        }


        public static Rectangle GetRect()
        {
            rect = new Rectangle(x, y, width, height);
            return rect;
        }

        public static void PlayerKeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.A: isLeft = true; break;
                case Keys.D: isRight = true; break;
                case Keys.W: Up = true; break;
                case Keys.S: Down = true; break;
            }
        }

        public static void PlayerKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: isLeft = false; break;
                case Keys.D: isRight = false; break;
                case Keys.W: Up = false; break;
                case Keys.S: Down = false; break;
            }
        }

        
        public static void Move()
        {
            if (isLeft && x > Allowance_Left) 
                x -= car_speed;
 
            if (isRight && x < Allowance_Right)
                x += car_speed;
            
            if (Up && y > Allowance_Up)
                y -= car_speed;
    
            if (Down && y < Allowance_Down)
                y += car_speed;

            rect = new Rectangle(x, y, width, height);
        }


        public static void Player_Paint(object sender, PaintEventArgs e)
        {
            if (!isInvincible || blinkCounter % 2 == 0)
            {
                e.Graphics.DrawImage(playerImage, rect);
            }
            DrawHearts(e);
        }


        public static void DrawHearts(PaintEventArgs e)
        {
            int heartSize = 30;
            int startX = 0;
            int startY = 60;
            int spacing = 40;

            for (int i = 0; i < currentLives; i++)
            {
                int xPos = startX + i * spacing;
                int yPos = startY;

                if (i < currentLives)
                {
                    e.Graphics.DrawImage(heartImage, xPos, yPos, heartSize, heartSize);
                }
                else
                {
                    e.Graphics.DrawRectangle(Pens.Gray, xPos, yPos, heartSize, heartSize);
                    e.Graphics.DrawString("❤", heartsFont, Brushes.Gray, xPos + 5, yPos + 5);
                }
            }
        }


        public static bool LoseLife()
        {
            if (isInvincible)
            {  
                return false;
            }

            Sound.PlayPlayerExplosion();
            currentLives--;

            if (currentLives == 0)
            {
                Sound.PlayPlayerExplosion();
                return true; 
            }
            
            isInvincible = true;
            blinkCounter = 0;
            invincibilityTimer.Start();

            return false;
        }

       
        private static void InvincibilityTimer_Tick(object sender, EventArgs e)
        {
            blinkCounter++;
            if (blinkCounter > 15) 
            {
                isInvincible = false;
                invincibilityTimer.Stop();
                blinkCounter = 0;
            }
        }

       
        public static void Reset()
        {
            x = 400;
            y = 500;
            isLeft = false;
            isRight = false;
            Up = false;
            Down = false;
            currentLives = lives;
            isInvincible = false;
            invincibilityTimer.Stop();
            blinkCounter = 0;
        }

       
        public static int GetLives()
        {
            return lives;
        }
    }
}
