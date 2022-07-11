using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Podkasto.Data.Mappings
{
    public class PodcastDbContextFactory : IDesignTimeDbContextFactory<PodcastDbContext>
    {
        public PodcastDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PodcastDbContext>();
            optionsBuilder.UseSqlite("Data Source=Podkasto.db");

            return new PodcastDbContext(optionsBuilder.Options);
        }
    }
}