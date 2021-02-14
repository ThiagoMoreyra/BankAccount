using System;

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
            if (bank.Valid)
                _bankRepository.Add(bank);
        }

        public Bank GetBankById(Guid id)
        {
            return _bankRepository.GetById(id).Result;
        }
    }
}
