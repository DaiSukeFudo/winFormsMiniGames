using System;
using System.IO;
using System.Media;
using System.Windows.Media;
using System.Diagnostics;


namespace Game
{
    public class Sound
    {
        public static void Off()
        {
            //Properties.Resources.bitcoin.Dispose(); // !!!!!!!!!!!!!!!!!!!!!!!!!!!
            Properties.Settings.Default.SoundStatus = false;
        }


        static SoundPlayer collectBitcoin;
        public static void CreateBitcoinCollect()
        {
            collectBitcoin = new SoundPlayer(Properties.Resources.collectBitcoin);
        }
        public static void PlayBitcoinCollect()
        {
            collectBitcoin.Play();
        }
        public static void RemoveBitcoinCollect()
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
        public static void RemovePlayerExplosion()
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
            if (Properties.Settings.Default.SoundStatus)
            {
                musicMain.Play();
            }
        }
        public static void RemoveMenuMusic()
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