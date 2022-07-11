using System;
using System.Collections.Generic;

namespace Podkasto.Models
{
    public class Podcast : IEntity
    {
        
        #region Properties
        
        /// <summary>
        /// An internal ID representing the podcast.
        /// </summary>
        public Guid ID { get; init; }

        /// <summary>
        /// The title of the podcast.
        /// </summary>
        public string PodcastTitle { get; set; } = string.Empty;

        /// <summary>
        /// The custom title set by the user.
        /// </summary>
        public string? CustomTitle { get; set; }
        
        /// <summary>
        /// The name of the author.
        /// </summary>
        public string Author { get; set; } = string.Empty;
        
        /// <summary>
        /// A description of the podcast.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The URL of the podcast.
        /// </summary>
        public string URL { get; set; } = string.Empty;

        /// <summary>
        /// The contact email associated with the podcast.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The language the podcast is recorded in.
        /// </summary>
        public string Language { get; set; } = string.Empty;
        
        /// <summary>
        /// The URL of the podcast cover.
        /// </summary>
        public string? ImageURL { get; set; }

        /// <summary>
        /// The ID of the podcast feed.
        /// </summary>
        public Guid FeedID { get; set; }
        
        /// <summary>
        /// AN object representing the podcasts feed.
        /// </summary>
        public Feed? Feed { get; set; }

        /// <summary>
        /// The last date time that the feed was pulled.
        /// </summary>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// An enumerable of episodes contained in the feed.
        /// </summary>
        public IEnumerable<Episode> Episodes { get; set; } = new List<Episode>();
        
        #endregion
    }
}