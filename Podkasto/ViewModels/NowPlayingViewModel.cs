using Podkasto.Models;
using Podkasto.Services.Interfaces;

namespace Podkasto.ViewModels
{
    public class NowPlayingViewModel : ViewModelBase
    {
        #region Fields

        private readonly IAudioService _audioService;
        private readonly IFeedClient _feedClient;

        #endregion
        
        #region Properties

        public bool IsPlaying => _audioService.IsPlaying;
        public Episode? CurrentEpisode { get; private set; }
        public string? CurrentEpisodeMediaURI => CurrentEpisode?.MediaURI;

        #endregion

        #region Constructors

        public NowPlayingViewModel(IAudioService audioService, IFeedClient feedClient)
        {
            _audioService = audioService;
            _feedClient = feedClient;
        }

        #endregion

        #region Methods

        public void PlayEpisode(Episode episode)
        {
            CurrentEpisode = episode;
            
            if (CurrentEpisodeMediaURI is null) return;
            
            if (_audioService.IsPlaying)
            {
                _audioService.PauseAsync();
            }
            _audioService.InitializeAsync(CurrentEpisodeMediaURI);
            _audioService.PlayAsync();
        }

        public void TogglePlayback()
        {
            if (_audioService.IsPlaying)
            {
                _audioService.PauseAsync();
            }
            else
            {
                _audioService.PlayAsync();
            }
        }

        #endregion
    }
}