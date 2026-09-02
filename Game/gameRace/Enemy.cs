using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    internal class Enemy : GameObject
    {
        private int speed;
        Random random = new Random();

        private const int MAX_X = 540;
        private const int MIN_X = 200;
        private const int SCREEN_HEIGHT = 600;

        public Enemy(int x, int y, int width, int height, Image image,int speed ) : base(x, y, width, height, image)
        {
            this.speed = speed;
        }

        public override void Update()
        {
            y += speed;

            if(y > SCREEN_HEIGHT)
            {
                Respawn();
            }
        }

        public void Reset()
        {
            y = random.Next(-500, -50);
            x = random.Next(MIN_X, MAX_X);
        }

        private void Respawn()
        {
            y = random.Next(-500, -50);
            x = random.Next(MIN_X, MAX_X);
        }
    }
}