using Microsoft.EntityFrameworkCore;
using Models;
using Mappings;

namespace Models
{
    public class Context : DbContext
    {
        public DbSet<Product> Products {get; set;}
        public DbSet<Transaction> Transactions {get; set;}
        public DbSet<Category> Categories {get; set;}

        public Context(DbContextOptions<Context> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new TransactionsMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
    }
}