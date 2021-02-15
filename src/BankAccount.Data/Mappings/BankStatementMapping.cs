using BankAccount.Domain.BankStatements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccount.Data.Mappings
{
    public class BankStatementMapping : IEntityTypeConfiguration<BankStatement>
    {
        public void Configure(EntityTypeBuilder<BankStatement> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(p => p.AvaliableBalance)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(p => p.TransactionDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.TransactionType)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.ToTable("tbBankStatement");
        }
    }
}
