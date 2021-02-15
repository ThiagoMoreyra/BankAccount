using System;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.Withdrawals
{
    public interface IWithdrawalUseCase
    {
        Task<bool> Withdrawal(Guid idAccount, double amount);
    }
}
