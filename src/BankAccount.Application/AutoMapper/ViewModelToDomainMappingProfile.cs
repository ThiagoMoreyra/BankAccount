using AutoMapper;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.Clients;
using BankAccount.Domain.Shared.ValueObjects;
using BankAccount.Domain.Transactions;

namespace BankAccount.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AccountViewModel, Account>();
            CreateMap<BankViewModel, Bank>();

            CreateMap<OwnerViewModel, Owner>()
                .ConstructUsing(p => new Owner(
                        new Name(p.FirstName, p.LastName), p.BirthDay, new Cpf(p.Cpf), new Address(p.Street, p.Number, p.Neighborhood, p.City, p.State, p.Country, p.ZipCode)));

            CreateMap<TransactionViewModel, Transaction>();            
        }
    }
}
