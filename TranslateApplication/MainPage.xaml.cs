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

namespace TranslateApplication
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Window window;
        public MainPage(Window window)
        {
            InitializeComponent();
            this.window = window;
            Configs.Init();
        }


        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            window.Close();
        }

        private void OpenTranslateWindowButtonClick(object sender, RoutedEventArgs e)
        {
            new TranslateWindow().Show();
        }

        private void ShowLearnedWordsButtonClick(object sender, RoutedEventArgs e)
        {
            new LearnedWordsWindow().Show();
        }

        private void OpenGamesButtonClick(object sender, RoutedEventArgs e)
        {
            new GamesWindow().Show();
        }
    }
}
