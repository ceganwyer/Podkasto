using System;

namespace Podkasto.Models
{
    public class FeedCategory
    {

        #region Properties

        /// <summary>
        /// The ID of the Feed.
        /// </summary>
        public Guid FeedID { get; init; }

        /// <summary>
        /// The ID of the category.
        /// </summary>
        public Guid CategoryID { get; init; }

        /// <summary>
        /// The Category.
        /// </summary>
        public Category? Category { get; set; }

        #endregion
    }
}