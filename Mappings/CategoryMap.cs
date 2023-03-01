using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Mappings
{
    public class CategoryMap : IEntityTypeConfiguration <Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.Name).HasMaxLength(30).IsRequired();

            builder.HasMany(c => c.Products).WithOne(c => c.Category);

            builder.ToTable("Categories");

        }
    }
}