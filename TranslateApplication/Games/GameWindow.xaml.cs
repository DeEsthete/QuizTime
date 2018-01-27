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

namespace TranslateApplication.Games
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow(Games game)
        {
            InitializeComponent();
            switch (game)
            {
                case Games.LosedLetter: Content = new LosenLetterGame(this); break;
                case Games.Quiz:Content = new Quiz(this);break;
                case Games.SpeedTraining: Content = new SpeedTraining(this);break;
            }
        }
    }
}
