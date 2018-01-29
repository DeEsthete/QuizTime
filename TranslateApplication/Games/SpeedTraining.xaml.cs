using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TranslateApplication.Games
{
    /// <summary>
    /// Логика взаимодействия для SpeedTraining.xaml
    /// </summary>
    public partial class SpeedTraining : Page
    {
        private Window window;
        private DispatcherTimer timer;
        private TextBlock secondsViewer;
        private const int TIME = 180;
        private int lettersCount;
        private int seconds;
        private const int LETTERS_IN_TEXT = 30;
        private string letters;

        public SpeedTraining(Window window)
        {
            InitializeComponent();
            this.window = window;
            window.Closed += (send, args) =>
            {
                if (timer != null)
                {
                    if (timer.IsEnabled)
                    {
                        timer.Stop();
                    }
                }
            };
        }
        private void StartGameButtonClick(object sender, RoutedEventArgs e)
        {
            seconds = 0;
            lettersCount = 0;
            grid.Children.Remove(startGameButton);

            secondsViewer = new TextBlock();

            window.KeyDown += KeyboardKeyDown;

            grid.Children.Add(secondsViewer);
            Grid.SetRow(secondsViewer, 1);

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += (send, args) => {
                seconds++;
                secondsViewer.Text = seconds.ToString();
                if (seconds >= TIME)
                {
                    timer.Stop();
                    MessageBox.Show(string.Format("Ваша скорость {0} букв в секундну",Math.Round((double)lettersCount/ seconds, 2)));
                    window.Close();
                }
            };
            timer.Start();
            letters = "";
            GenerateLetters();
        }

        private void GenerateLetters()
        {
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            for(int i = 0; i < LETTERS_IN_TEXT; i++)
            {
                letters += alpha[random.Next(0, alpha.Length)];
            }
            text.Text = letters;
        }

        private void KeyboardKeyDown(object sender, KeyEventArgs args)
        {
            if (timer.IsEnabled)
            {
                if (letters.Length == 0) GenerateLetters();
                else
                {
                    if (args.Key.ToString().ToLower() == letters[0].ToString())
                    {
                        letters = letters.Remove(0, 1);
                        text.Text = letters;
                        lettersCount++;
                        if (letters.Length == 0) GenerateLetters();
                    }
                }
            }
        }
    }
}
