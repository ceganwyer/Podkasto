using System.Net.Http;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Podkasto.Data;
using Podkasto.Services;
using Podkasto.Services.Interfaces;
using Podkasto.ViewModels;
using Podkasto.Views;

namespace Podkasto
{
    public partial class App : Application
    {
        private static MainViewModel? s_mainViewModel;

        public App()
        {
            var configBuilder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", false, true);
            var config = configBuilder.Build();
            
            var serviceProvider = new ServiceCollection()
                                 .AddDbContext<PodcastDbContext>(options =>
                                  {
                                      options.UseSqlite(config.GetConnectionString("Sqlite"));
                                  })
                                 .AddSingleton(config)
                                 .AddSingleton<HttpClient>()
                                 .AddSingleton<IAudioService, VLCAudioService>()
                                 .AddSingleton<IFeedClient, FeedClient>()
                                 .AddSingleton<MainViewModel>()
                                 .AddSingleton<NowPlayingViewModel>()
                                 .AddSingleton<QueueViewModel>()
                                 .AddSingleton<SubscriptionsViewModel>()
                                 .AddSingleton<AddPodcastViewModel>()
                                 .AddSingleton<EpisodesViewModel>()
                                 .AddSingleton<DownloadsViewModel>()
                                 .AddSingleton<HistoryViewModel>()
                                 .AddSingleton<SettingsViewModel>()
                                 .BuildServiceProvider();
            
            s_mainViewModel = serviceProvider.GetService<MainViewModel>();
        }
        
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = s_mainViewModel,
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}