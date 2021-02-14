using AutoMapper;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.BankStatements;

namespace BankAccount.Application.UseCases.RegisterBankStatement
{
    public class RegisterBankStatementUseCase: IRegisterBankStatementUseCase
    {
        private readonly IBankStatementService _bankStatementService;
        private readonly IMapper _mapper;

        public RegisterBankStatementUseCase(IBankStatementService bankStatementService, IMapper mapper)
        {
            _bankStatementService = bankStatementService;
            _mapper = mapper;
        }

        public void RegisterBank(BankStatementViewModel bankStatementViewModel)
        {
            var bankStatement = _mapper.Map<BankStatement>(bankStatementViewModel);
            _bankStatementService.RegisterBankStatement(bankStatement);
        }
    }
}
