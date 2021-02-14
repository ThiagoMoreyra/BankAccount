using BankAccount.Application.ViewModels;

namespace BankAccount.Application.UseCases.Banks
{
    public interface IRegisterBankUseCase
    {
        void RegisterBank(BankViewModel bankViewModel);
    }
}
