using GalaSoft.MvvmLight;

namespace MatchingGame.ViewModels
{
    public sealed class LoadingPageViewModel : ViewModelBase
    {
        public LoadingPageViewModel()
        {
        }

        public string Title { get; private set; } = "Matching Game in Wpf";
    }

}
