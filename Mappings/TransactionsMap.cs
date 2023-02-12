using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gerenciador.Mappings
{
    public class TransactionsMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.TransactionID);

            builder.Property(t => t.Description).HasMaxLength(100).IsRequired();
            builder.Property(t => t.DateTransaction).IsRequired();

            builder.HasOne(t => t.Product).WithMany(t => t.Transactions).HasForeignKey(t => t.ProductId).IsRequired();

            builder.ToTable("Transaction");
        }
    }
}