using System;
using System.Threading.Tasks;

namespace BankAccount.Domain.Accounts
{
    public interface IAccountService
    {
        void RegisterAccount(Account account);
        decimal GetAvaliableBalance(double fee, Account account);
        Task<Account> GetAccountById(Guid id);
        void UpdateAccount(Account account);
    }
}
