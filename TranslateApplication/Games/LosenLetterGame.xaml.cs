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
    /// Логика взаимодействия для LosenLetterGame.xaml
    /// </summary>
    public partial class LosenLetterGame : Page
    {
        private int correctAnswers;
        private Window window;
        private DispatcherTimer timer;
        private DispatcherTimer delayTimer;
        private int seconds;
        private const int ALL_SECONDS = 180;

        private List<string> words;
        private string wordWithLosenLetter;
        private string word;
        private int letterIndex;
        private int rightButton;

        private void Tick(object sender,EventArgs e)
        {
            seconds++;
            if (seconds == ALL_SECONDS)
            {
                timer.Stop();
                MessageBox.Show(string.Format("Игра окончена\nВы набрали: {0} баллов", correctAnswers));
                window.Close();
            }
            timeBox.Text = seconds.ToString();
        }

        public LosenLetterGame(Window window)
        {
            InitializeComponent();
            this.window = window;
            window.Closed += (send, args) =>
            {
                if (timer!=null){
                    if (timer.IsEnabled) timer.Stop();
                    if (delayTimer.IsEnabled) delayTimer.Stop();
                }
            };
            seconds = 0;

            correctAnswers = 0;
            words = new List<string>(Configs.GetAllWordsFrom(TranslatorFiles.BaseDirectory));

            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            timer.Tick += Tick;
            delayTimer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 5)
            };
            delayTimer.Tick += Delay;

            timer.Start();
            ChangeWords();
        }

        private void Delay(object sender, EventArgs e)
        {
                timer.Start();
                delayTimer.Stop();
                firstLetter.Background = Brushes.White;
                secondLetter.Background = Brushes.White;
                thirdLetter.Background = Brushes.White;
                fourthLetter.Background = Brushes.White;
                ChangeWords();
        }
        private char GetRandomLetter(int seed)
        {
            Random random = new Random(seed);
            
            char[] alpha = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char letter;
            do
            {
                letter = alpha[random.Next(0, alpha.Length)];
            } while (letter == word[letterIndex]);
            return letter;
        }

        public void ChangeWords()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            word = words[random.Next(0,words.Count)];
            letterIndex = random.Next(0, word.Length);

            if (wordWithLosenLetter != "") wordWithLosenLetter = "";
            for(int i = 0; i < word.Length; i++)
            {
                if (i != letterIndex) wordWithLosenLetter += word[i];
                else wordWithLosenLetter += "_";
            }

            wordTextBox.Text = wordWithLosenLetter;

   
            rightButton = random.Next(1, 5);
            switch (rightButton)
            {
                case 1:firstLetter.Content = word[letterIndex];
                    secondLetter.Content = GetRandomLetter(DateTime.Now.Millisecond);
                    thirdLetter.Content = GetRandomLetter(DateTime.Now.Month);
                    fourthLetter.Content = GetRandomLetter(DateTime.Now.Second);
                    break;
                case 2:
                    firstLetter.Content = GetRandomLetter(DateTime.Now.Millisecond);
                    secondLetter.Content = word[letterIndex];
                    thirdLetter.Content = GetRandomLetter(DateTime.Now.Month);
                    fourthLetter.Content = GetRandomLetter(DateTime.Now.Second);
                    break;
                case 3:
                    firstLetter.Content = GetRandomLetter(DateTime.Now.Millisecond);
                    secondLetter.Content = GetRandomLetter(DateTime.Now.Month);
                    thirdLetter.Content = word[letterIndex];
                    fourthLetter.Content = GetRandomLetter(DateTime.Now.Second);
                    break;
                case 4:
                    firstLetter.Content = GetRandomLetter(DateTime.Now.Millisecond);
                    secondLetter.Content = GetRandomLetter(DateTime.Now.Month);
                    thirdLetter.Content = GetRandomLetter(DateTime.Now.Second);
                    fourthLetter.Content = word[letterIndex];
                    break;
            }
        }

        private void FirstLetterClick(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                if (rightButton == 1)
                {
                    correctAnswers++;
                    firstLetter.Background = Brushes.Green;
                    delayTimer.Start();
                    timer.Stop();
                }
                else
                {
                    firstLetter.Background = Brushes.Red;
                    delayTimer.Start();
                    timer.Stop();
                }
            }
        }
        private void SecondLetterClick(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                if (rightButton == 2)
                {
                    correctAnswers++;
                    secondLetter.Background = Brushes.Green;
                    delayTimer.Start();
                    timer.Stop();
                }
                else
                {
                    secondLetter.Background = Brushes.Red;
                    delayTimer.Start();
                    timer.Stop();
                }
            }
        }
        private void ThirdLetterClick(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                if (rightButton == 3)
                {
                    correctAnswers++;
                    thirdLetter.Background = Brushes.Green;
                    delayTimer.Start();
                    timer.Stop();
                }
                else
                {
                    thirdLetter.Background = Brushes.Red;
                    delayTimer.Start();
                    timer.Stop();
                }
            }
        }
        private void FourthLetterClick(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                if (rightButton == 4)
                {
                    correctAnswers++;
                    fourthLetter.Background = Brushes.Green;
                    delayTimer.Start();
                    timer.Stop();
                }
                else
                {
                    fourthLetter.Background = Brushes.Red;
                    delayTimer.Start();
                    timer.Stop();
                }
            }   
        }
    }
}
