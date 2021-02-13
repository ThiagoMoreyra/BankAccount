using BankAccount.Domain.Shared.Data;

namespace BankAccount.Domain.Transactions
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
    }
}
