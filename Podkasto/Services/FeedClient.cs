using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Podkasto.Data;
using Podkasto.Models;
using Podkasto.Services.Interfaces;

namespace Podkasto.Services
{
    public class FeedClient : IFeedClient
    {
        private static readonly XmlSerializer RSSXmlSerializer = new(typeof(RSS));
        private static readonly XmlSerializer AtomXmlSerializer = new(typeof(Atom));
        private readonly IConfigurationRoot _configuration;
        private readonly HttpClient _httpClient;
        private readonly ILogger<FeedClient> _logger;
        private readonly PodcastDbContext _podcastDbContext;

        public FeedClient(HttpClient httpClient, IConfigurationRoot config, PodcastDbContext podcastDbContext)
        {
            _configuration = config;
            _httpClient = httpClient;
            //_logger = logger;
            _podcastDbContext = podcastDbContext;
        }

        public async Task<Podcast> GetPodcastAsync(Feed feed, CancellationToken cancellationToken)
        {
            await using var feedStream = await _httpClient.GetStreamAsync(feed.URL, cancellationToken);
            var imagesStorage = _configuration["Storage:Images"];
            
            var podcast = feed.FeedType switch
            {
                FeedType.Atom => GetPodcastFromAtom(feedStream, imagesStorage),
                FeedType.RSS => GetPodcastFromRSS(feedStream, imagesStorage),
                _ => throw new ArgumentOutOfRangeException()
            };

            return podcast;
        }

        public async Task AddFeedAsync(PodcastDbContext podcastDbContext, string url,
                                       IReadOnlyCollection<string> feedCategories, FeedType type,
                                       CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        private static Podcast GetPodcastFromRSS(Stream stream, string imagesStorage)
        {
            throw new NotImplementedException();
        }

        private static Podcast GetPodcastFromAtom(Stream stream, string imagesStorage)
        {
            throw new NotImplementedException();
        }
    }
}