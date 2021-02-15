using BankAccount.Application.ViewModels;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.Banks
{
    public interface IRegisterBankUseCase
    {
        Task<bool> RegisterBank(BankViewModel bankViewModel);
    }
}
