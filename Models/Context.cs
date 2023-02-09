using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gerenciador.Models;
using Gerenciador.Mappings;

namespace Gerenciador.Models
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