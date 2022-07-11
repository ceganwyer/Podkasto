using System;
using System.Threading.Tasks;
using LibVLCSharp.Shared;
using Podkasto.Services.Interfaces;

namespace Podkasto.Services
{
    public class VLCAudioService : IAudioService
    {
        #region Fields

        private string? _uri;
        private MediaPlayer? _mediaPlayer;
        private static readonly LibVLC LibVlc = new LibVLC(enableDebugLogs: true);

        #endregion

        #region Properties

        /// <inheritdoc />
        public bool IsPlaying => _mediaPlayer is not null && _mediaPlayer.State == VLCState.Playing;
        /// <inheritdoc />
        public float CurrentPosition => _mediaPlayer?.Position ?? 0;
        /// <inheritdoc />
        public event EventHandler<bool>? IsPlayingChanged;

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task InitializeAsync(string audioURI)
        {
            _uri = audioURI;

            if (_mediaPlayer is null)
            {
                var media = new Media(LibVlc, new Uri(_uri), ":no-video");
                _mediaPlayer = new MediaPlayer(media);
            }

            if (_mediaPlayer is not null)
            {
                await PauseAsync();
                _mediaPlayer.Media = new Media(LibVlc, new Uri(_uri), ":no-video");
            }
        }

        /// <inheritdoc />
        public Task PlayAsync(float position = 0)
        {
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.Position = position;
                _mediaPlayer.Play();
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task PauseAsync()
        {
            _mediaPlayer?.Pause();
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task SetMuted(bool muted)
        {
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.Mute = muted;
            }
            
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task SetVolume(int volume)
        {
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.Volume = volume;
            }
            
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task SetCurrentTime(float position)
        {
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.Position = position;
            }
            
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public ValueTask DisposeAsync()
        {
            _mediaPlayer?.Dispose();
            
            return ValueTask.CompletedTask;
        }

        #endregion
    }
}