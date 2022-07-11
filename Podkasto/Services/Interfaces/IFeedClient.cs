using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Podkasto.Data;
using Podkasto.Models;

namespace Podkasto.Services.Interfaces
{
    public interface IFeedClient
    {
        /// <summary>
        /// Retrieves the feed from it's url and maps it to a 
        /// </summary>
        /// <param name="feed"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Podcast> GetPodcastAsync(Feed feed, CancellationToken cancellationToken);

        Task AddFeedAsync(PodcastDbContext podcastDbContext, string url, IReadOnlyCollection<string> feedCategories,
                          FeedType type, CancellationToken cancellationToken);
    }
}