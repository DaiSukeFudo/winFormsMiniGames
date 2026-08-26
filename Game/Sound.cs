using System;
using System.IO;
using System.Media;
using System.Windows.Media;
using System.Diagnostics;


namespace Game
{
    public class Sound
    {
        static SoundPlayer collectBitcoin;
        public static void CreateBitcoinCollect()
        {
            collectBitcoin = new SoundPlayer(Properties.Resources.collectBitcoin);
        }
        public static void PlayBitcoinCollect()
        {
            collectBitcoin.Play();
        }
        public static void StopBitcoinCollect()
        {
            if(collectBitcoin != null)
            {
                collectBitcoin.Stop();
                collectBitcoin.Dispose();
                collectBitcoin = null;
            }
        }


        static SoundPlayer explosionSound;
        public static void CreatePlayerExplosion()
        {
            explosionSound = new SoundPlayer(Properties.Resources.explosion);
        }
        public static void PlayPlayerExplosion()
        {
            explosionSound.Play();
        }
        public static void StopPlayerExplosion()
        {
            if(explosionSound != null)
            {
                explosionSound.Stop();
                explosionSound.Dispose();
                explosionSound = null;
            }
        }


        static private SoundPlayer musicMain;
        public static void CreateMenuMusic()
        {
            musicMain = new SoundPlayer(Properties.Resources.mainMenuMusic);
        }
        public static void PlayMenuMusic()
        {
            musicMain.Play();
        }
        public static void StopMenuMusic()
        {
            if(musicMain != null)
            {
                musicMain.Stop();
                musicMain.Dispose();
                musicMain = null;
            }
        }
    }
}