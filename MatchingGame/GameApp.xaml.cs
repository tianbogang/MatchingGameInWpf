using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MatchingGame.Views;
using MatchingGame.ViewModels;
using MatchingGame.Service;

namespace MatchingGame
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class GameApp : Application
    {
        public static GameApp Instance => (Current as GameApp);

        private readonly ServiceProvider serviceProvider;
        public ServiceProvider Provider => serviceProvider;

        public GameApp()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterMvvm(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
           services.AddSingleton<IGameService, GameService>();
        }

        private void RegisterMvvm(IServiceCollection services)
        {
            services.AddSingleton<LoadingPageViewModel>();
            services.AddSingleton<NewGameViewModel>();
            services.AddSingleton<PlayGameViewModel>();
            services.AddSingleton<GameOverViewModel>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddTransient<LoadingPage>();
            services.AddTransient<NewGame>();
            services.AddTransient<PlayGame>();
            services.AddTransient<GameOver>();
            // services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // MainWindow wnd = serviceProvider.GetService<MainWindow>();
            MainWindowViewModel viewModel = serviceProvider.GetService<MainWindowViewModel>();
            MainWindow wnd = new MainWindow(viewModel);
            wnd.Show();

            base.OnStartup(e);
        }
    }
}
