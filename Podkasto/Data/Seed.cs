using System;
using System.Collections.Generic;
using Podkasto.Models;

namespace Podkasto.Data
{
    public class Seed
    {
        internal static readonly IEnumerable<Feed> Feeds = new List<Feed>()
        {
            new() { ID = new Guid("9d41d750-3907-4adf-9095-1d6f17a5d254"), URL = "http://feeds.codenewbie.org/cnpodcast.xml" },
        };

        internal static readonly IEnumerable<Category> Categories = new List<Category>()
        {
            new() { ID = new Guid("fb866ceb-63ed-4b11-825b-201a61c89c47"), Genre = "Comedy" },
        };

        internal static readonly IEnumerable<FeedCategory> FeedCategories = new List<FeedCategory>()
        {
            new() { FeedID = new Guid("9d41d750-3907-4adf-9095-1d6f17a5d254"),
                CategoryID = new Guid("fb866ceb-63ed-4b11-825b-201a61c89c47") },
        };
    }
}