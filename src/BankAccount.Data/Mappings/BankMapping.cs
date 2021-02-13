using BankAccount.Domain.Banks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccount.Data.Mappings
{
    public class BankMapping : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.BankCode)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.CompanyName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasMany(p => p.Accounts)
                .WithOne(p => p.Bank)
                .HasForeignKey(p => p.IdBank)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("tbBank");
        }
    }
}
