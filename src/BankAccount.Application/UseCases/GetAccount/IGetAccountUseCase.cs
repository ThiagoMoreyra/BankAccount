using System;

namespace BankAccount.Application.UseCases.GetAccount
{
    public interface IGetAccountUseCase
    {
        decimal GetAvaliableAccount(double fee, Guid idAccount);
    }
}
