using BankAccount.Application.ViewModels;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.RegisterOwner
{
    public interface IRegisterOwnerUseCase
    {
        Task<bool> RegisterOwner(OwnerViewModel ownerViewModel);
    }
}
