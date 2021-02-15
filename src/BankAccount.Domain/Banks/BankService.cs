using System;
using System.Threading.Tasks;

namespace BankAccount.Domain.Banks
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<bool> RegisterBank(Bank bank)
        {
            return await _bankRepository.Add(bank);            
        }

        public Bank GetBankById(Guid id)
        {
            return _bankRepository.GetById(id).Result;
        }
    }
}
