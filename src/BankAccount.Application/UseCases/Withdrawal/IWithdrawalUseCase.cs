using System;

namespace BankAccount.Application.UseCases.Withdrawals
{
    public interface IWithdrawalUseCase
    {
        void Withdrawal(Guid idAccount, double amount);
    }
}
