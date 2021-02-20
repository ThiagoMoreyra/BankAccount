using System.Threading.Tasks;

namespace BankAccount.Domain.Transactions.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<bool> RegisterTransaction(Transaction transaction)
        {
            if (transaction.Invalid) return false;

            return await _transactionRepository.Add(transaction);
        }
    }
}
