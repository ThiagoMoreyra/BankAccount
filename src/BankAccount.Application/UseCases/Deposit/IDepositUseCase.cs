using System;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.Deposits
{
    public interface IDepositUseCase
    {
        Task<bool> Deposit(Guid idAccount, double amount)
    }
}
