using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    internal class Sound
    {
        static SoundPlayer collectB = new SoundPlayer(Properties.Resources.collectBitcoin);
        static SoundPlayer musicMain = new SoundPlayer(Properties.Resources.mainMenuMusic);
        public static void BitcoinCollect()
        {
            collectB.Play();
        }
        public static void music()
        {
            musicMain.Play();
        }

    }
}
