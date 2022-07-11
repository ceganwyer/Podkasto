using System;

namespace Podkasto.Models
{
    public class UserFeed : IEntity
    {
        #region Properties
        
        public Guid ID { get; init; }
        
        public string URL { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
        
        public string Categories { get; set; } = string.Empty;

        #endregion
    }
}