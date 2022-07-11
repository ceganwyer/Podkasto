using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Podkasto.Models;

namespace Podkasto.Data
{
    public class PodcastDbContext : DbContext
    {
        private IConfigurationRoot _configuration;
        
        protected PodcastDbContext()
        {
        }

        public PodcastDbContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Podcast> Podcasts => Set<Podcast>();
        public DbSet<Feed> Feeds { get; set; }
        //public DbSet<UserFeed> UserFeeds => Set<UserFeed>();
        //public DbSet<Episode> Episodes => Set<Episode>();
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            modelBuilder.Entity<Feed>().HasData(Seed.Feeds);
            modelBuilder.Entity<Category>().HasData(Seed.Categories);
            modelBuilder.Entity<FeedCategory>().HasData(Seed.FeedCategories);
            modelBuilder.Entity<FeedCategory>().HasKey(fc => new { fc.FeedID, fc.CategoryID });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}