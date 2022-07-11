using System;
using System.Collections.Generic;

namespace Podkasto.Models
{
    public class Feed : IEntity
    {
        
        #region Properties

        /// <summary>
        /// The ID of the feed.
        /// </summary>
        public Guid ID { get; init; }
        
        /// <summary>
        /// The URL of the feed.
        /// </summary>
        public string URL { get; init; } = string.Empty;
        
        /// <summary>
        /// The type of the podcast feed.
        /// </summary>
        public FeedType FeedType { get; set; }
        
        /// <summary>
        /// The podcast represented by this feed.
        /// </summary>
        public Podcast? Podcast { get; set; }
        
        /// <summary>
        /// The categories this feed belongs to.
        /// </summary>
        public ICollection<FeedCategory> Categories { get; } = new List<FeedCategory>();

        #endregion
    }
}