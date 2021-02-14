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

        public void RegisterAccount(Account account)
        {
            _accountRepository.Add(account);
        }

        public decimal GetAvaliableBalance(double fee, Account account)
        {
            return account.GetAvaliableDailyProfitBalance(fee);
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            return await _accountRepository.GetById(id);
        }

        public void UpdateAccount(Account account)
        {
            _accountRepository.Update(account);
        }
    }
}
