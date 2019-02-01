using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Scrabble
{
    public class Scrabble : IDisposable
    {
        internal static readonly string PrivateKey = "vC0b033V36 7L5g2226c1 05e6lqkQcC B2re0SF5l1 ip542Bsy0U";
        public ScrabbleWindow ActiveWindow;

        public Random Random;
        public readonly Settings Settings;

        public SoundPlayer BackgroundMusic;

        public Timer Timer;

        public static bool IsLoaded ;

        public Game ActiveGame;
        public ScrabbleWords Words;
        public bool WordsLoaded;
        public string[] Names;
        public Thread Loader;
        public Scrabble()
        {
            Random = new Random();
            Settings = new Settings();
            Timer = new Timer { Interval = 100 };
            InitializeBackgroundMusic();            
        }

        private void InitializeBackgroundMusic()
        {
            try
            {
                BackgroundMusic = new SoundPlayer(Utilities.LoadResource("Scrabble.Resources.Track01.wav"));
                BackgroundMusic.Load();
                if (Settings.EnableMusic)
                {
                    BackgroundMusic.PlayLooping();
                }
            }
            catch(Exception)
            {
                Settings.EnableMusic = false;                
            }

        }

        public string GetRandomName()
        {
            while (!IsLoaded)
            {
                Thread.Sleep(100);
            }
            return Names[Random.Next(Names.Length)];
        }

        public void Run()
        {
            Loader = new Thread(() =>
            {
                using (var r = new StreamReader(Utilities.LoadResource("Scrabble.Resources.Names.txt")))
                {
                    var names = new List<string>();
                    string name;
                    while ((name = r.ReadLine()) != null)
                        names.Add(name);
                    Names = names.ToArray();
                }
                Words =
                    new ScrabbleWords(new[] { Utilities.LoadResource("Scrabble.Resources.Dictionary.txt") });
                IsLoaded = true;
            });
            Loader.Start();
            Timer.Start();
            ActiveWindow = new ScrabbleWindow(this);

            Application.EnableVisualStyles();
            Application.Run(ActiveWindow);
        }

        public void Dispose()
        {
            if(ActiveWindow != null && !ActiveWindow.IsDisposed)
                ActiveWindow.Dispose();
            Timer.Stop();
            Timer.Dispose();            
            Loader = null;           
        }

        [STAThread]
        public static void Main(string[] args)
        {
            
            using (var scrabble = new Scrabble())
            {
                scrabble.Run();
            }            
        }       
        
    }
}
