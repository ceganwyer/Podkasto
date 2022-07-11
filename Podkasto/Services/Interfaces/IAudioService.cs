using System;
using System.Threading.Tasks;

namespace Podkasto.Services.Interfaces
{
    public interface IAudioService
    {
        /// <summary>
        /// Indicates if playback is in progress.
        /// </summary>
        bool IsPlaying { get; }
        
        /// <summary>
        /// Gets the current playback position. Returns 0 if no playback is in progress.
        /// </summary>
        float CurrentPosition { get; }

        /// <summary>
        /// Event handler for IsPlaying.
        /// </summary>
        event EventHandler<bool> IsPlayingChanged;

        /// <summary>
        /// Initializes the audio service
        /// </summary>
        /// <param name="audioURI">The URI of the audio file to be played.</param>
        /// <returns>A <see cref="Task"/> representing the result of an asynchronous operation.</returns>
        Task InitializeAsync(string audioURI);

        /// <summary>
        /// Begins playback of the audio file.
        /// </summary>
        /// <param name="position">The position to begin playback from.</param>
        /// <returns>A <see cref="Task"/> representing the result of an asynchronous operation.</returns>
        Task PlayAsync(float position = 0);

        /// <summary>
        /// Halts playback of the audio file.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of an asynchronous operation.</returns>
        Task PauseAsync();

        /// <summary>
        /// Mutes the media player.
        /// </summary>
        /// <param name="muted"></param>
        /// <returns>A <see cref="Task"/> representing the result of an asynchronous operation.</returns>
        Task SetMuted(bool muted);

        /// <summary>
        /// Sets the volume of the media player.
        /// </summary>
        /// <param name="volume"></param>
        /// <returns>A <see cref="Task"/> representing the result of an asynchronous operation.</returns>
        Task SetVolume(int volume);

        /// <summary>
        /// Changes the position of the media player.
        /// </summary>
        /// <param name="position"></param>
        /// <returns>A <see cref="Task"/> representing the result of an asynchronous operation.</returns>
        Task SetCurrentTime(float position);

        /// <summary>
        /// Disposes the media player.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> representing the result of an asynchronous operation.</returns>
        ValueTask DisposeAsync();

    }
}