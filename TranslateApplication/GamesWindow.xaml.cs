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
using System.Windows.Shapes;

namespace TranslateApplication
{
    /// <summary>
    /// Логика взаимодействия для GamesWindow.xaml
    /// </summary>
    public partial class GamesWindow : Window
    {
        public GamesWindow()
        {
            InitializeComponent();
        }

        private void CloseWindowButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LosenLetterGameWindowOpenButtonClick(object sender, RoutedEventArgs e)
        {
            new Games.GameWindow(Games.Games.LosedLetter).Show();
        }

        private void QuizButtonClick(object sender, RoutedEventArgs e)
        {
            new Games.GameWindow(Games.Games.Quiz).Show();
        }

        private void SpeedTrainingButtonClick(object sender, RoutedEventArgs e)
        {
            new Games.GameWindow(Games.Games.SpeedTraining).Show();
        }

        private void SpeedQuizButtonClick(object sender, RoutedEventArgs e)
        {
            new Games.GameWindow(Games.Games.SpeedQuiz).Show();
        }
    }
}
