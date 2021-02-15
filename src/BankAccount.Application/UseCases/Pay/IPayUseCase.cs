using System;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.Pays
{
    public interface IPayUseCase
    {
        Task<bool> Pay(Guid idAccount, double amount);
    }
}
