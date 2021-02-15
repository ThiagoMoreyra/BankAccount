using System;

namespace BankAccount.Application.UseCases.GetAccount
{
    public interface IGetAccountUseCase
    {
        decimal GetAvaliableBalance(double fee, Guid idAccount);

        decimal GetBalance(Guid idAccount);
    }
}
