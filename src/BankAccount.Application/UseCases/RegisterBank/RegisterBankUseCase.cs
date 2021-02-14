using AutoMapper;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Banks;

namespace BankAccount.Application.UseCases.Banks
{
    public class RegisterBankUseCase: IRegisterBankUseCase
    {
        private readonly IBankService _bankService;
        private readonly IMapper _mapper;

        public RegisterBankUseCase(IBankService bankService, IMapper mapper)
        {
            _bankService = bankService;
            _mapper = mapper;
        }

        public void RegisterBank(BankViewModel bankViewModel)
        {
            var bank = _mapper.Map<Bank>(bankViewModel);
            _bankService.RegisterBank(bank);
        }
    }
}
