namespace Podkasto.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(NowPlayingViewModel nowPlayingView,
                             QueueViewModel queueView,
                             SubscriptionsViewModel subscriptionsView,
                             AddPodcastViewModel addPodcastView,
                             EpisodesViewModel episodesView,
                             DownloadsViewModel downloadsView,
                             HistoryViewModel historyView,
                             SettingsViewModel settingsView)
        {
            NowPlayingView = nowPlayingView;
            QueueView = queueView;
            SubscriptionsView = subscriptionsView;
            AddPodcastView = addPodcastView;
            EpisodesView = episodesView;
            DownloadsView = downloadsView;
            HistoryView = historyView;
            SettingsView = settingsView;
        }


        #region Properties

        public NowPlayingViewModel NowPlayingView { get; }
        public QueueViewModel QueueView { get; }
        public SubscriptionsViewModel SubscriptionsView { get; }
        public AddPodcastViewModel AddPodcastView { get; }
        public EpisodesViewModel EpisodesView { get; }
        public DownloadsViewModel DownloadsView { get; }
        public HistoryViewModel HistoryView { get; }
        public SettingsViewModel SettingsView { get; }

        #endregion
    }
}