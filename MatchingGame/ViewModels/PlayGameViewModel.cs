using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MatchingGame.Core;
using MatchingGame.Service;

namespace MatchingGame.ViewModels
{
    public sealed class PlayGameViewModel : ViewModelBase, IDisposable
    {
        private IGameService gameService = null;

        public PlayGameViewModel(IGameService gameService)
        {
            this.gameService = gameService;

            ClickedCardOnUno = new RelayCommand<int>(this.OnClickedCardInSet1);
            ClickedCardOnDue = new RelayCommand<int>(this.OnClickedCardInSet2);

            Messenger.Default.Register<string>(this, HandleNotification);
        }

        private void HandleNotification(string notification)
        {
            if (notification == "PlaygameInit")
            {
                Init();
            }
        }

        public List<Card> Cardset1 => gameService.CurrentGame?.CardSet1;
        public List<Card> Cardset2 => gameService.CurrentGame?.CardSet2;

        public ICommand ClickedCardOnUno { get; }
        public ICommand ClickedCardOnDue { get; }

        private async void OnClickedCardInSet1(int point)
        {
            await gameService.CurrentGame.UpdateCardFromUno(point).ConfigureAwait(false);
            CheckAndStop();
        }

        private async void OnClickedCardInSet2(int point)
        {
            await gameService.CurrentGame.UpdateCardFromDue(point).ConfigureAwait(false);
            CheckAndStop();
        }

        private void CheckAndStop()
        {
            if(gameService.CurrentGame.RemainCards == 0)
            {
                gameService.CurrentGame.TimeUsed = timeElapsed;
                CleanUp();
                Messenger.Default.Send(GameLifeCycle.GameOver);
            }
        }

        private void Init()
        {
            if(this.gameService.CurrentGame != null)
            {
                this.gameService.CurrentGame.CardStateChanged += OnPlayerFaceChanged;
            }

            StartTimer();
        }

        private void CleanUp()
        {
            if (this.gameService.CurrentGame != null)
            {
                this.gameService.CurrentGame.CardStateChanged -= OnPlayerFaceChanged;
            }

            StopTimer();
        }

        private PlayerFace player = PlayerFace.Watch;
        public PlayerFace Player
        {
            get
            {
                return player;
            }
            private set
            {
                player = value;
                RaisePropertyChanged("Player");
            }
        }

        private void OnPlayerFaceChanged(PlayerFace face)
        {
            Player = face;
        }

        private System.Threading.Timer timer;
        private long tick = 0;
        private TimeSpan timeElapsed;
        public string TimeElapsed => timeElapsed.ToString(@"hh\:mm\:ss");

        private void StartTimer()
        {
            tick = 0;
            timer = new System.Threading.Timer(_ =>
            {
                tick++;
                timeElapsed = TimeSpan.FromSeconds(tick);
                RaisePropertyChanged("TimeElapsed");
            }, null, 0, 1000);
        }

        private void StopTimer()
        {
            timer?.Dispose();
            timer = null;
        }

        public void Dispose()
        {
            Cleanup();
        }
    }
}
