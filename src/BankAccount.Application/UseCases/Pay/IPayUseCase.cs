using System;

namespace BankAccount.Application.UseCases.Pays
{
    public interface IPayUseCase
    {
        void Pay(Guid idAccount, double amount);
    }
}
