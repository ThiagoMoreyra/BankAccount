using System;
using System.Threading.Tasks;

namespace BankAccount.Domain.Accounts
{
    public interface IAccountService
    {
        Task<bool> RegisterAccount(Account account);
        decimal GetAvaliableBalance(double fee, Account account);
        Task<Account> GetAccountById(Guid id);
        Task<bool> UpdateAccount(Account account);
    }
}
