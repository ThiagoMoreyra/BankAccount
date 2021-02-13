namespace BankAccount.Domain.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void RegisterTransaction(Transaction transaction)
        {
            _transactionRepository.Add(transaction);
        }
    }
}
