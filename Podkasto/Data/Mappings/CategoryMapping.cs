using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Podkasto.Models;

namespace Podkasto.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.ID).HasColumnName("ID").IsRequired();
            builder.Property(c => c.Genre).IsRequired();
        }
    }
}