using GalaSoft.MvvmLight;

namespace MatchingGame.Core
{
    public class Card: ViewModelBase
    {
        public Card(int point, CardState state)
        {
            Point = point;
            State = state;
        }

        public int Point { get; }

        private CardState state = CardState.Closed;
        public CardState State 
        { 
            get { return state; } 
            set
            {
                state = value;
                RaisePropertyChanged("State");
            }
        } 
    }
}
