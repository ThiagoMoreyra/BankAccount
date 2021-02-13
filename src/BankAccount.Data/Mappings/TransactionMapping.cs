using BankAccount.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BankAccount.Data.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IdAccount)
                .IsRequired()
                .HasColumnType("binary(32)");

            builder.Property(p => p.IdBank)
                .IsRequired()
                .HasColumnType("binary(32)");

            builder.ToTable("tbTransactions");
        }
    }
}
