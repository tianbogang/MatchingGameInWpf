using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using MatchingGame.Core;

namespace MatchingGame.Views
{
    /// <summary>
    /// Interaction logic for LoadingPage.xaml
    /// </summary>
    public partial class LoadingPage : UserControl
    {
        public LoadingPage()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            Messenger.Default.Send(GameLifeCycle.NewGame);
        }
    }
}
