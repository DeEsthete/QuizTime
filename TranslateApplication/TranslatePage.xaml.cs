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
    /// Логика взаимодействия для TranslatePage.xaml
    /// </summary>
    public partial class TranslatePage : Page
    {
        private Window window;
        private TextTranslator translator;
        public TranslatePage(Window window)
        {
            InitializeComponent();
            this.window = window;
            translator = new TextTranslator();

            foreach(var language in translator.GetLanguages())
            {
                langFrom.Items.Add(language);
                langTo.Items.Add(language);
            }
            langFrom.SelectedItem = langFrom.Items[0];
            langTo.SelectedItem = langFrom.Items[0];
        }

        private void TranslateButtonClick(object sender, RoutedEventArgs e)
        {
            string word = new TextRange(commonWordBox.Document.ContentStart, commonWordBox.Document.ContentEnd).Text;
            translatedWordBox.Text = translator.Translate(word, translator.GetLangPair(langFrom.SelectedItem as string, langTo.SelectedItem as string));
        }

        private void SwapButtonClick(object sender, RoutedEventArgs e)
        {
            var item = langTo.SelectedItem;
            langTo.SelectedItem = langFrom.SelectedItem;
            langFrom.SelectedItem = item;
        }
    }
}
