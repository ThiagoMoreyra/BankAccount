namespace BankAccount.Domain.Banks
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public void RegisterBank(Bank bank)
        {
            _bankRepository.Add(bank);
        }
    }
}
