using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MatchingGame.Core;
using MatchingGame.Service;

namespace MatchingGame.ViewModels
{
    public sealed class NewGameViewModel : ViewModelBase
    {
        private IGameService gameService = null;

        public NewGameViewModel(IGameService gameService)
        {
            this.gameService = gameService;

            StartGame = new RelayCommand<GameDifficulty>(this.StartNewGame);
        }

        public ICommand StartGame { get; }

        private async void StartNewGame(GameDifficulty difficulty)
        {
            await Task.Run(() => {
                gameService.CreateNewGame((int)difficulty);
            });

            Messenger.Default.Send(GameLifeCycle.PlayGame);
        }

    }
}
