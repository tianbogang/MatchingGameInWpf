using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace MatchingGame.Views
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : UserControl
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<string>("GameoverInit");
        }
    }
}
