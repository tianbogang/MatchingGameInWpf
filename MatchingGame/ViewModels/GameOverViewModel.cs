using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MatchingGame.Core;
using MatchingGame.Service;

namespace MatchingGame.ViewModels
{
    public sealed class GameOverViewModel : ViewModelBase
    {
        private IGameService gameService = null;

        public GameOverViewModel(IGameService gameService)
        {
            this.gameService = gameService;

            PlayAgain = new RelayCommand(() => Messenger.Default.Send(GameLifeCycle.PlayAgain));

            Messenger.Default.Register<string>(this, HandleNotification);
        }

        public ICommand PlayAgain { get; }

        public string TimeUsed { get; private set; }

        private void HandleNotification(string notification)
        {
            if(notification == "GameoverInit")
            {
                TimeUsed = this.gameService.CurrentGame.TimeUsed.ToString(@"hh\:mm\:ss");
                RaisePropertyChanged("TimeUsed");
            }
        }
    }
}
