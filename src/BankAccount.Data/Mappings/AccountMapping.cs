using BankAccount.Domain.Accounts;
using BankAccount.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccount.Data.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Number)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.BankCode)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.Balance)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(p => p.CreationDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasOne(p => p.Owner)
                .WithOne(p => p.Account)
                .HasForeignKey<Owner>(p => p.IdAccount);

            builder.HasMany(p => p.Transactions)
                .WithOne(p => p.Account)
                .HasForeignKey(p => p.IdAccount)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("tbAccount");
        }
    }
}
