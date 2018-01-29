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
    /// Логика взаимодействия для QuizTime.xaml
    /// </summary>
    public partial class QuizTime : Page
    {
        private int correctAnswers;
        private Window window;
        private List<string> words;
        private string word;
        private int rightButton;
        private TextTranslator translator;
        private DispatcherTimer timer;
        private const int TIME = 10;
        private int seconds = 0;

        public QuizTime(Window window)
        {
            InitializeComponent();
            this.window = window;
            correctAnswers = 0;

            words = new List<string>(Configs.GetAllWordsFrom(TranslatorFiles.BaseDirectory));
            translator = new TextTranslator();
            
            window.Closed+=(send,args)=>
            {
                if (timer != null)
                {
                    if (timer.IsEnabled) timer.Stop();
                }
            };

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += (send, args) => {
                seconds++;
                secondsViewer.Text = seconds.ToString();
                if (seconds >= TIME)
                {
                    timer.Stop();
                    MessageBox.Show(string.Format("Вы правильно ответили на {0} вопросов", correctAnswers));
                    window.Close();
                }
            };

            timer.Start();

            ChangeWords();
        }

        private string GetRandomWord(int seed)
        {
            Random random = new Random(seed);
            int indexOfWord = random.Next(0, words.Count);
            string tmpWord = words[indexOfWord];
            words.RemoveAt(indexOfWord);
            return tmpWord;
        }

        private void ChangeWords()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            int index = random.Next(0, words.Count);
            word = words[index];

            rightButton = random.Next(1, 4);
            switch (rightButton)
            {
                case 1:
                    firstWord.Content = word;
                    secondWord.Content = GetRandomWord(DateTime.Now.Minute);
                    thirdWord.Content = GetRandomWord(DateTime.Now.Day);
                    fourthWord.Content = GetRandomWord(DateTime.Now.Second);
                    break;
                case 2:
                    firstWord.Content = GetRandomWord(DateTime.Now.Minute);
                    secondWord.Content = word;
                    thirdWord.Content = GetRandomWord(DateTime.Now.Day);
                    fourthWord.Content = GetRandomWord(DateTime.Now.Second);
                    break;
                case 3:
                    firstWord.Content = GetRandomWord(DateTime.Now.Minute);
                    secondWord.Content = GetRandomWord(DateTime.Now.Day);
                    thirdWord.Content = word;
                    fourthWord.Content = GetRandomWord(DateTime.Now.Second);
                    break;
                case 4:
                    firstWord.Content = GetRandomWord(DateTime.Now.Minute);
                    secondWord.Content = GetRandomWord(DateTime.Now.Day);
                    thirdWord.Content = GetRandomWord(DateTime.Now.Second);
                    fourthWord.Content = word;
                    break;
            }
            wordTextBox.Text = translator.Translate(word, translator.GetLangPair("Английский", "Русский"));
        }

        private void FirstWordClick(object sender, RoutedEventArgs e)
        {
            if (rightButton == 1)
            {
                correctAnswers++;
            }
            ChangeWords();
        }
        private void SecondWordClick(object sender, RoutedEventArgs e)
        {
            if (rightButton == 2)
            {
                correctAnswers++;
            }
            ChangeWords();
        }
        private void ThirdWordClick(object sender, RoutedEventArgs e)
        {
            if (rightButton == 3)
            {
                correctAnswers++;
            }
            ChangeWords();
        }
        private void FourthWordClick(object sender, RoutedEventArgs e)
        {
            if (rightButton == 4)
            {
                correctAnswers++;
            }
            ChangeWords();
        }
    }
}
