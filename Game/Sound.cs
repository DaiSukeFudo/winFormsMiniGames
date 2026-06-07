using System.Media;


namespace Game
{
    internal class Sound
    {

        private static int mainVolume = 1;
        private static SoundPlayer collectB = new SoundPlayer(Properties.Resources.collectBitcoin);
        private static SoundPlayer musicMain = new SoundPlayer(Properties.Resources.mainMenuMusic);
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