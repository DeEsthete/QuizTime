using System;
using System.Collections.Generic;
using System.IO;
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
using TranslateApplication;

namespace Autorun
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private int index;
        private Window window;
        private List<string> words;

        public MainPage(Window window)
        {
            InitializeComponent();
            this.window = window;

            words = new List<string>(Configs.GetAllWordsFrom(TranslatorFiles.NotLearnedWords));

            if (words.Count != 0)
            {

                Random random = new Random(DateTime.Now.Millisecond);
                index = random.Next(0, words.Count - 1);

                TextTranslator translator = new TextTranslator();

                commonWordBox.Text = words[index];
                translatedWordBox.Text = translator.Translate(words[index], translator.GetLangPair("Английский", "Русский"));
            }
            else
            {
                MessageBox.Show("Поздравляем, вы выучили все слова в словаре!");
                window.Close();
            }
        }

        private void LearnedButtonClick(object sender, RoutedEventArgs e)
        {
            Configs.AddToFile(TranslatorFiles.LearnedWords, words[index]);
            words.RemoveAt(index);

            window.Close();
        }
        private void NotLearnedButtonClick(object sender, RoutedEventArgs e)
        {
            window.Close();
        }
    }
}
