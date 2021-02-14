using BankAccount.Application.ViewModels;

namespace BankAccount.Application.UseCases.RegisterOwner
{
    public interface IRegisterOwnerUseCase
    {
        void RegisterBank(OwnerViewModel ownerViewModel);
    }
}
