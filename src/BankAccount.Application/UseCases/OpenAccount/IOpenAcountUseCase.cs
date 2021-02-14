using BankAccount.Application.ViewModels;

namespace BankAccount.Application.UseCases.Accounts
{
    public interface IOpenAcountUseCase
    {
        void RegisterAccount(AccountViewModel accountViewModel);
    }
}
