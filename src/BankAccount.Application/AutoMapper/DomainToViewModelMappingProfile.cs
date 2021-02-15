using AutoMapper;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Accounts;
using BankAccount.Domain.Banks;
using BankAccount.Domain.Clients;
using BankAccount.Domain.Transactions;

namespace BankAccount.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Account, AccountViewModel>();
            CreateMap<Bank, BankViewModel>();

            CreateMap<Owner, OwnerViewModel>()
                    .ForMember(d => d.City, o => o.MapFrom(s => s.Address.City))
                    .ForMember(d => d.Country, o => o.MapFrom(s => s.Address.Country))
                    .ForMember(d => d.Neighborhood, o => o.MapFrom(s => s.Address.Neighborhood))
                    .ForMember(d => d.Number, o => o.MapFrom(s => s.Address.Number))
                    .ForMember(d => d.ZipCode, o => o.MapFrom(s => s.Address.ZipCode))
                    .ForMember(d => d.State, o => o.MapFrom(s => s.Address.State))
                    .ForMember(d => d.Street, o => o.MapFrom(s => s.Address.Street))
                    .ForMember(d => d.Document, o => o.MapFrom(s => s.Cpf.Document))
                    .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Name.FirstName))
                    .ForMember(d => d.LastName, o => o.MapFrom(s => s.Name.LastName)).ReverseMap();

            CreateMap<Transaction, TransactionViewModel>();
        }
    }
}
