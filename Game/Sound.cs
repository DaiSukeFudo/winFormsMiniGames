using System;
using System.Media;


namespace Game
{
    internal class Sound
    {
        static SoundPlayer collectB = new SoundPlayer(Properties.Resources.collectBitcoin);
        static SoundPlayer musicMain = new SoundPlayer(Properties.Resources.mainMenuMusic);
        static SoundPlayer explosionSound = new SoundPlayer(Properties.Resources.explosion);
        public static void BitcoinCollect()
        {
            
            collectB.Play();
        }
        public static void music()
        {
            musicMain.Play();
        }
        public static void PlayExplosionWithStopMusic()
        {
            musicMain.Stop();
            explosionSound.Play();
        }
    }
}