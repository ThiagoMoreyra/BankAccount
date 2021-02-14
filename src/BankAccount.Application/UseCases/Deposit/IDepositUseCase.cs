using System;

namespace BankAccount.Application.UseCases.Deposits
{
    public interface IDepositUseCase
    {
        void Deposit(Guid idAccount, double amount);
    }
}
