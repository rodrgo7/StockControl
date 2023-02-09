using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gerenciador.Models;

namespace Gerenciador.Mappings
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