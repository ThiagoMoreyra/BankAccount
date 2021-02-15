using System;
using System.Threading.Tasks;

namespace BankAccount.Domain.Accounts
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> RegisterAccount(Account account)
        {
            if (account.Invalid) return false;

            return await _accountRepository.Add(account);            
        }

        public decimal GetAvaliableBalance(double fee, Account account)
        {
            return account.GetAvaliableDailyProfitBalance(fee);
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            return await _accountRepository.GetById(id);
        }

        public async Task<bool> UpdateAccount(Account account)
        {
            if (account.Invalid) return false;

            return await _accountRepository.Update(account);           
        }
    }
}
