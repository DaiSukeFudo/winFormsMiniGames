using System;
using System.Drawing;
using System.Windows.Forms;


namespace Game
{
    internal class Player : GameObject
    {
        private int lives = 3;
        private int speed = 20;
        private int currentLives;

        private bool isInvincible = false;
        private int blinkCounter = 0;
        private Timer invincibilityTimer;

        private bool isLeft = false;
        private bool isRight = false;
        private bool isUp = false;
        private bool isDown = false;

        private const int MIN_X = 200;
        private const int MAX_X = 540;
        private const int MIN_Y = 0;
        private const int MAX_Y = 530;

        private static Image heartImage = Properties.Resources.health;
        private const int HEART_SIZE = 30;
        private const int HEART_START_X = 0;
        private const int HEART_START_Y = 60;
        private const int HEART_SPACING = 40;



        public Player(int x, int y, int width, int height, Image image): base(x, y, width, height, image) 
        {
            currentLives = lives;
            invincibilityTimer = new Timer();
            invincibilityTimer.Interval = 100;
            invincibilityTimer.Tick += InvincibilityTimer_Tick;
        }

        public override void Update()
        {
            if (isLeft && x > MIN_X) x -= speed;
            if (isRight && x < MAX_X) x += speed;
            if (isUp && y > MIN_Y) y -= speed;
            if (isDown && y < MAX_Y) y += speed;
        }

        public override void Draw(Graphics g)
        {
            if(!isInvincible || blinkCounter % 2 == 0)
            {
                g.DrawImage(image, x, y, width, height );
            }
            DrawHearts(g);
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.A: isLeft = true; break;
                case Keys.D: isRight = true; break;
                case Keys.W: isUp = true; break;
                case Keys.S: isDown = true; break;
            }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: isLeft = false; break;
                case Keys.D: isRight = false; break;
                case Keys.W: isUp = false; break;
                case Keys.S: isDown = false; break;
            }
        }


        public bool TakeDamage()
        {
            if (isInvincible) return false;

            Sound.PlayPlayerExplosion();

            currentLives--;

            if(currentLives <= 0)
            {
                Sound.PlayPlayerExplosion();
                return true;
            }

            isInvincible = true;
            blinkCounter = 0;
            invincibilityTimer.Start();

            return false;
        }

        public void Reset()
        {
            x = 400;
            y = 500;
            currentLives = lives;
            isInvincible = false;
            blinkCounter = 0;
            invincibilityTimer.Stop();

            isLeft = false;
            isRight = false;
            isUp = false;
            isDown = false;
        }

        public int GetLives()
        {
            return currentLives;
        }
       
        private void DrawHearts(Graphics g)
        {
            for (int i = 0; i < currentLives; i++)
            {
                int xPos = HEART_START_X + i * HEART_SPACING;
                int yPos = HEART_START_Y;
                g.DrawImage(heartImage, xPos, yPos, HEART_SIZE, HEART_SIZE);
            }
        }

        private void InvincibilityTimer_Tick(object sender, EventArgs e)
        {
            blinkCounter++;
            if (blinkCounter > 15) 
            {
                isInvincible = false;
                invincibilityTimer.Stop();
                blinkCounter = 0;
            }
        }
    }
}
