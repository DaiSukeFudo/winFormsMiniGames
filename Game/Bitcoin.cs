using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Game.Collision;

namespace Game
{
    internal class Bitcoin
    {

        private static int x = 220;
        private static int y = -100;
        private static int bitok_speed = 20;

        private static Random random = new Random();
        private static bool isActive = true;


        private static int width = 64;
        private static int height = 32;
        private static Rectangle rect;


        private static Label bitcoinCounterLabel;

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
            isActive = true;
            y = random.Next(-500, -50); 
            x = random.Next(200, 540);   
            
        }


        public static void CreateBitcoinCounter(Race form)
        {
            bitcoinCounterLabel = new Label();

            bitcoinCounterLabel.Location = new Point(5, 10);
            bitcoinCounterLabel.Size = new Size(150, 30);
            bitcoinCounterLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            bitcoinCounterLabel.ForeColor = Color.Gold;
            bitcoinCounterLabel.BackColor = Color.Transparent;

            bitcoinCounterLabel.Parent = form;
            bitcoinCounterLabel.BringToFront();
            form.Controls.Add(bitcoinCounterLabel);

            bitcoinCounterLabel.Text = $"bitcoins: {GameStats.BitcoinCount}";
        }



        public static void Collect()
        {
            isActive = false;
        }



        public static void Bitok_Print(object sender, PaintEventArgs e)
        {
                e.Graphics.DrawImage(Properties.Resources.bitcoin, x, y, width, height);
        }



        public static void Reset()
        {
            isActive = true;
            x = random.Next(200, 540);
            y = random.Next(-500, -50);
            GameStats.BitcoinCount = 0;
        }
    }
}
