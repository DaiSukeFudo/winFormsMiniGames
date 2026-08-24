using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    internal class UIControl
    {
        public static Label CreateText(string text, Point location)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(0, 5);
            label.Font = new Font("Arial", 14);
            label.ForeColor = Color.Gold;

            label.BringToFront();
            label.AutoSize = true;
            return label;
        }

        //public static Rectangle GetRect()
        //{
        //    rect = new Rectangle(x, y, width, height);
        //    return rect;
        //}


        //public static void Move()
        //{
        //    y += bitok_speed;

        //    if (y > 600)
        //    {
        //        Respawn();
        //    }
        //    rect = new Rectangle(x, y, width, height);
        //}


        //public static void Respawn()
        //{
        //    y = random.Next(-500, -50);
        //    x = random.Next(200, 540);
        //}


        ////public static void CreateBitcoinCounter(Race form)
        ////{
        ////    form.Controls.Add(bitcoinCounterLabel);
        ////    bitcoinCounterLabel.Text = $"bitcoins: {countOfBitcoins}";
        ////}

        //public static void CreateBitcoinCounter(Race form)
        //{
        //    // Пересоздаем Label заново для новой формы, чтобы избежать ObjectDisposedException
        //    Label bitcoinCounterLabel = new Label();

        //    // Настройте внешний вид (добавьте эти строки, если вам нужно настроить шрифт или цвет)
        //    bitcoinCounterLabel.Font = new Font("Arial", 14);
        //    bitcoinCounterLabel.ForeColor = Color.GreenYellow;
        //    bitcoinCounterLabel.AutoSize = true;
        //    bitcoinCounterLabel.Location = new Point(0, 60); // Размещаем чуть ниже distUI, чтобы они не перекрывали друг друга

        //    // Присваиваем текст
        //    bitcoinCounterLabel.Text = $"bitcoins: {countOfBitcoins}";

        //    // Добавляем созданный Label на текущую форму игры
        //    form.Controls.Add(bitcoinCounterLabel);
        //}

        //public static void Collect()
        //{
        //    Sound.BitcoinCollect();
        //    countOfBitcoins++;
        //    bitcoinCounterLabel.Text = $"bitcoins: {countOfBitcoins}";
        //    bitcoinCounterLabel.Update();
        //    Respawn();
        //}


        //public static void Bitok_Print(object sender, PaintEventArgs e)
        //{
        //    e.Graphics.DrawImage(bitcoinImage, rect);
        //}


        //public static void Reset()
        //{
        //    Respawn();
        //    countOfBitcoins = 0;
        //    bitcoinCounterLabel.Text = $"bitcoins: {countOfBitcoins}";
        //    bitcoinCounterLabel.Update();
        //}
    }
}
