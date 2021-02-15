using BankAccount.Application.ViewModels;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.Accounts
{
    public interface IOpenAccountUseCase
    {
        Task<bool> RegisterAccount(AccountViewModel accountViewModel);
    }
}
