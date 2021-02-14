using BankAccount.Application.ViewModels;

namespace BankAccount.Application.UseCases.Accounts
{
    public interface IOpenAccountUseCase
    {
        void RegisterAccount(AccountViewModel accountViewModel);
    }
}
