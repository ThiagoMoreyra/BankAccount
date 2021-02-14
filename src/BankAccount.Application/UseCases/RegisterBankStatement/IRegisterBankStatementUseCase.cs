using BankAccount.Application.ViewModels;

namespace BankAccount.Application.UseCases.RegisterBankStatement
{
    public interface IRegisterBankStatementUseCase
    {
        void RegisterBank(BankStatementViewModel bankStatementViewModel);
    }
}
