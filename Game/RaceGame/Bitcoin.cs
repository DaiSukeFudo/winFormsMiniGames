using System;
using System.Drawing;
using System.Windows.Forms;


namespace Game
{
    internal class Bitcoin
    {
        private static Image bitcoinImage = Properties.Resources.bitcoin;
        private static int x = 220;
        private static int y = -100;
        private static int bitok_speed = 10;
        private static Random random = new Random();
        private static int countOfBitcoins = 0;
        private static int width = 32;
        private static int height = 32;
        private static Rectangle rect;


        public static Rectangle GetRect()
        {
            rect = new Rectangle(x, y, width, height);
            return rect;
        }


        public static void Move()
        {
           y += bitok_speed;

           if (y > 600)
           {
               Respawn();
           }
           rect = new Rectangle(x, y, width, height);
        }


        public static void Respawn()
        {
            y = random.Next(-500, -50); 
            x = random.Next(200, 540);       
        }


        public static void Collect(Label bitcoinLabel)
        {
            Respawn();
            Sound.PlayBitcoinCollect();
            countOfBitcoins++;
            bitcoinLabel.Text = $"bitcoins: {countOfBitcoins}";
        }


        public static void Bitcoin_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitcoinImage, rect);
        }


        public static void Reset(Label bitcoinLabel)
        {
            Respawn();
            countOfBitcoins = 0;
            bitcoinLabel.Text = $"bitcoins: {countOfBitcoins}";
            bitcoinLabel.Update();
        }
    }
}
