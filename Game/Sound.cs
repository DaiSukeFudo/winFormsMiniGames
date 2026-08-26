using System;
using System.IO;
using System.Media;
using System.Windows.Media;
using System.Diagnostics;


namespace Game
{
    public class Sound
    {
        //private static readonly string bitcoinSoundPath;

        //static Sound()
        //{
        //    try
        //    {
        //        // Используем системную временную папку, чтобы не засорять папку с программой
        //        string tempFolder = Path.GetTempPath();
        //        bitcoinSoundPath = Path.Combine(tempFolder, "app_collect_bitcoin.wav");

        //        // Извлекаем аудиопоток из вашего Resources.resx
        //        // Примечание: Если имя файла ресурсов отличается от стандартного Resources, 
        //        // замените "Properties.Resources" на ваше имя (например, Properties.Resource1)
        //        using (Stream stream = Properties.Resources.collectBitcoin)
        //        {
        //            if (stream != null)
        //            {
        //                using (FileStream fileStream = new FileStream(bitcoinSoundPath, FileMode.Create, FileAccess.Write))
        //                {
        //                    stream.CopyTo(fileStream);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Не удалось подготовить аудиофайл: {ex.Message}");
        //    }
        //}

        //public static void PlayBitcoinCollect()
        //{
        //    // Проверяем, существует ли временный файл перед воспроизведением
        //    if (string.IsNullOrEmpty(bitcoinSoundPath) || !File.Exists(bitcoinSoundPath))
        //        return;

        //    try
        //    {
        //        // Каждый вызов создает изолированный плеер, что позволяет звукам накладываться
        //        MediaPlayer player = new MediaPlayer();
        //        player.Open(new Uri(bitcoinSoundPath, UriKind.Absolute));
        //        player.Play();
        //    }

        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Ошибка при воспроизведении звука: {ex.Message}");
        //    }
        //}


        static SoundPlayer collectBitcoin = new SoundPlayer(Properties.Resources.collectBitcoin);
        //static SoundPlayer musicMain = new SoundPlayer(Properties.Resources.mainMenuMusic);
        static SoundPlayer explosionSound = new SoundPlayer(Properties.Resources.explosion);




        public static void PlayBitcoinCollect()
        {
            collectBitcoin.Play();
        }


        //public static void PlayMenuMusic()
        //{
        //    musicMain.Play();
        //}

        //public static void StopMenuMusic()
        //{
        //    musicMain.Stop();
        //}


        public static void PlayPlayerExplosion()
        {
            explosionSound.Play();
        }

        static private SoundPlayer musicMain;

        public static void PlayMenuMusic()
        {
            musicMain = new SoundPlayer(Properties.Resources.mainMenuMusic);
            musicMain.Play();
        }

        public static void StopMenuMusic()
        {
            musicMain.Stop();
            musicMain.Dispose();
            musicMain = null;
        }
    }
}