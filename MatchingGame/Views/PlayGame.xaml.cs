using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace MatchingGame.Views
{
    /// <summary>
    /// Interaction logic for PlayGame.xaml
    /// </summary>
    public partial class PlayGame : UserControl
    {
        public PlayGame()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<string>("PlaygameInit");
        }
    }
}
