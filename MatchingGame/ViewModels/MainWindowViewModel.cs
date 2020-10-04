using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MatchingGame.Core;

namespace MatchingGame.ViewModels
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase loadingPageViewModel;
        private ViewModelBase newGameViewModel;
        private ViewModelBase playGameViewModel;
        private ViewModelBase gameOverViewModel;

        public MainWindowViewModel(
            LoadingPageViewModel loadingPageViewModel, NewGameViewModel newGameViewModel, PlayGameViewModel playGameViewModel, GameOverViewModel gameOverViewModel
        )
        {
            this.loadingPageViewModel = loadingPageViewModel;
            this.newGameViewModel = newGameViewModel;
            this.playGameViewModel = playGameViewModel;
            this.gameOverViewModel = gameOverViewModel;

            MainContent = this.loadingPageViewModel;

            Messenger.Default.Register<GameLifeCycle>(this, HandleOpenView);
        }

        public ViewModelBase MainContent { get; private set; }

        private void HandleOpenView(GameLifeCycle life)
        {
            if (life == GameLifeCycle.NewGame)
            {
                MainContent = this.newGameViewModel;
            }
            else if (life == GameLifeCycle.PlayGame)
            {
                MainContent = this.playGameViewModel;
            }
            else if (life == GameLifeCycle.GameOver)
            {
                MainContent = this.gameOverViewModel;
            }
            else if (life == GameLifeCycle.PlayAgain)
            {
                MainContent = this.newGameViewModel;
            }
            else
            {
                MainContent = this.loadingPageViewModel;
            }

            RaisePropertyChanged("MainContent");
        }
    }
}
