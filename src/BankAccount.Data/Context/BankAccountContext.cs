using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.Clients;
using BankAccount.Domain.Shared.Data;
using BankAccount.Domain.Shared.Notify;
using BankAccount.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankAccount.Data.Context
{
    public class BankAccountContext : DbContext, IUnitOfWork
    {
        public BankAccountContext(DbContextOptions<BankAccountContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<BankStatement> BankStatements { get; set; }
        public DbSet<Transaction> Transactions { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankAccountContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
