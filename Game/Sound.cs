using System;
using System.Media;


namespace Game
{
    internal class Sound
    {
        static SoundPlayer collectB = new SoundPlayer(Properties.Resources.collectBitcoin);
        static SoundPlayer musicMain = new SoundPlayer(Properties.Resources.mainMenuMusic);
        static SoundPlayer explosionSound = new SoundPlayer(Properties.Resources.explosion);
        
        public static void PlayBitcoinCollect()
        {    
            collectB.Play();
        }


        public static void PlayMenuMusic()
        {
            musicMain.Play();
        }

        public static void StopMenuMusic()
        {
            musicMain.Stop();
        }


        public static void PlayPlayerExplosion()
        {
            explosionSound.Play();
        }
    }
}