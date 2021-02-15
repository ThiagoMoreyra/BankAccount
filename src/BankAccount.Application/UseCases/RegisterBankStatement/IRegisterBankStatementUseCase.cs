using BankAccount.Application.ViewModels;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.RegisterBankStatement
{
    public interface IRegisterBankStatementUseCase
    {
        Task<bool> RegisterBank(BankStatementViewModel bankStatementViewModel);
    }
}
