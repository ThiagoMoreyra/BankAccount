using AutoMapper;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.BankStatements;
using BankAccount.Domain.Shared.Notify;
using System.Threading.Tasks;

namespace BankAccount.Application.UseCases.RegisterBankStatement
{
    public class RegisterBankStatementUseCase: IRegisterBankStatementUseCase
    {
        private readonly IBankStatementService _bankStatementService;
        private readonly IMapper _mapper;
        private readonly INotifiable _notifiable;

        public RegisterBankStatementUseCase(IBankStatementService bankStatementService, IMapper mapper, INotifiable notifiable)
        {
            _bankStatementService = bankStatementService;
            _mapper = mapper;
            _notifiable = notifiable;
        }

        public async Task<bool> RegisterBank(BankStatementViewModel bankStatementViewModel)
        {
            var bankStatement = _mapper.Map<BankStatement>(bankStatementViewModel);
            if (bankStatement.Invalid)
            {
                _notifiable.AddNotification(new Notification("Register failed - Invalid Fields"));
                return false;
            }                
            return await _bankStatementService.RegisterBankStatement(bankStatement);
        }
    }
}
