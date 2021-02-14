using BankAccount.Api.Filter;
using BankAccount.Application.UseCases.Deposits;
using BankAccount.Application.UseCases.Pays;
using BankAccount.Application.UseCases.Withdrawals;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Shared.Notify;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAccount.Api.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : MainController
    {
        private readonly INotifiable notifiable;
        private readonly IWithdrawalUseCase _withdrawalUseCase;
        private readonly IDepositUseCase _depositUseCase;
        private readonly IPayUseCase _payUseCase;
        public TransactionController(INotifiable notifiable, IWithdrawalUseCase withdrawalUseCase, IDepositUseCase depositUseCase, IPayUseCase payUseCase)
            : base(notifiable)
        {
            _withdrawalUseCase = withdrawalUseCase;
            _depositUseCase = depositUseCase;
            _payUseCase = payUseCase;
        }

        [ValidateModel]
        [HttpPost("withdrawal")]
        public async Task<IActionResult> Withdrawal([FromBody] TransactionViewModel transactionViewModel)
        {
            _withdrawalUseCase.Withdrawal(transactionViewModel.IdAccount, transactionViewModel.Amount);
            return CustomResponse(transactionViewModel);
        }

        [ValidateModel]
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] TransactionViewModel transactionViewModel)
        {
            _depositUseCase.Deposit(transactionViewModel.IdAccount, transactionViewModel.Amount);
            return CustomResponse(transactionViewModel);
        }

        [ValidateModel]
        [HttpPost("pay")]
        public async Task<IActionResult> Pay([FromBody] TransactionViewModel transactionViewModel)
        {
            _payUseCase.Pay(transactionViewModel.IdAccount, transactionViewModel.Amount);
            return CustomResponse(transactionViewModel);
        }
    }
}
