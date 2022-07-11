using System;

namespace Podkasto.Models
{
    public class Episode : IEntity
    {
        
        #region Properties
        
        /// <summary>
        /// An internal ID representing the episode.
        /// </summary>
        public Guid ID { get; init; }
        
        /// <summary>
        /// The title of the episode.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The provided description of the episode.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Indicates any content warning associated with the episode.
        /// </summary>
        public string Explicit { get; set; } = string.Empty;

        /// <summary>
        /// The date the episode was published.
        /// </summary>
        public DateTime PublishedDate { get; set;  }
        
        /// <summary>
        /// The duration of the episode.
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// The URL for the episode media.
        /// </summary>
        public string EpisodeURL { get; set; } = string.Empty;
        
        /// <summary>
        /// The URI of the media file that has been downloaded for this episode.
        /// </summary>
        public string? MediaURI { get; set; }

        /// <summary>
        /// The current state of the episode.
        /// </summary>
        public EpisodePlayState State { get; set; } = EpisodePlayState.Unplayed;

        /// <summary>
        /// The podcast this episode belongs to.
        /// </summary>
        public Podcast? Podcast { get; private set; } = null;

        #endregion

    }
}