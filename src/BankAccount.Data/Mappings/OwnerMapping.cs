using BankAccount.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccount.Data.Mappings
{
    public class OwnerMapping : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.BirthDay)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasOne(p => p.Account)
               .WithOne(p => p.Owner);               

            builder.OwnsOne(p => p.Name, c =>
            {
                c.Property(c => c.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("VARCHAR(100)");

                c.Property(c => c.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("VARCHAR(100)");
            });

            builder.OwnsOne(p => p.Cpf, c =>
            {
                c.Property(c => c.Number)
                    .HasColumnName("Cpf")
                    .HasColumnType("VARCHAR(100)");
            });

            builder.OwnsOne(p => p.Address, c =>
            {
                c.Property(c => c.City)
                    .HasColumnName("City")
                    .HasColumnType("VARCHAR(100)");

                c.Property(c => c.Country)
                    .HasColumnName("Country")
                    .HasColumnType("VARCHAR(100)");

                c.Property(c => c.Neighborhood)
                    .HasColumnName("Neighborhood")
                    .HasColumnType("VARCHAR(100)");

                c.Property(c => c.Number)
                    .HasColumnName("Number")
                    .HasColumnType("VARCHAR(100)");

                c.Property(c => c.State)
                    .HasColumnName("State")
                    .HasColumnType("VARCHAR(100)");

                c.Property(c => c.ZipCode)
                    .HasColumnName("ZipCode")
                    .HasColumnType("VARCHAR(100)");
            });

            builder.ToTable("tbOwner");
        }
    }
}
