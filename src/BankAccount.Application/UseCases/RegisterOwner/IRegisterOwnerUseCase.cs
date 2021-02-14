using BankAccount.Application.ViewModels;

namespace BankAccount.Application.UseCases.RegisterOwner
{
    public interface IRegisterOwnerUseCase
    {
        void RegisterOwner(OwnerViewModel ownerViewModel);
    }
}
