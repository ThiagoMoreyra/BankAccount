using BankAccount.Api.Filter;
using BankAccount.Application.UseCases.Deposits;
using BankAccount.Application.UseCases.GetAccount;
using BankAccount.Application.UseCases.GetBankStatement;
using BankAccount.Application.UseCases.Pays;
using BankAccount.Application.UseCases.Withdrawals;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Shared.Notify;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAccount.Api.Controllers
{
    [Route("api/v1/transactions")]
    [ApiController]
    public class TransactionController : MainController
    {
        private readonly INotifiable notifiable;
        private readonly IWithdrawalUseCase _withdrawalUseCase;
        private readonly IDepositUseCase _depositUseCase;
        private readonly IPayUseCase _payUseCase;
        private readonly IGetBankStatementUseCase _getBankStatementUseCase;
        public TransactionController(INotifiable notifiable, IWithdrawalUseCase withdrawalUseCase, IDepositUseCase depositUseCase, IPayUseCase payUseCase,
            IGetBankStatementUseCase getBankStatementUseCase) : base(notifiable)
        {
            _withdrawalUseCase = withdrawalUseCase;
            _depositUseCase = depositUseCase;
            _payUseCase = payUseCase;
            _getBankStatementUseCase = getBankStatementUseCase;
        }

        [ValidateModel]
        [HttpPost("withdrawal")]
        public async Task<IActionResult> Withdrawal([FromBody] TransactionViewModel transactionViewModel)
        {
            var result = await _withdrawalUseCase.Withdrawal(transactionViewModel.IdAccount, transactionViewModel.Amount);
            if (result)
                return CustomResponse(GetAvaliableAccount(transactionViewModel.IdAccount));

            return CustomResponse(transactionViewModel);
        }

        [ValidateModel]
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] TransactionViewModel transactionViewModel)
        {
            var result = await _depositUseCase.Deposit(transactionViewModel.IdAccount, transactionViewModel.Amount);
            if (result)
                return CustomResponse(GetAvaliableAccount(transactionViewModel.IdAccount));

            return CustomResponse(transactionViewModel);
        }

        [ValidateModel]
        [HttpPost("pay")]
        public async Task<IActionResult> Pay([FromBody] TransactionViewModel transactionViewModel)
        {
            var result = await _payUseCase.Pay(transactionViewModel.IdAccount, transactionViewModel.Amount);
            if (result)
                return CustomResponse(GetAvaliableAccount(transactionViewModel.IdAccount));

            return CustomResponse(transactionViewModel);
        }

        private string GetAvaliableAccount(Guid idAccount)
        {
            return $"Balance: {_getBankStatementUseCase.GetAvaliableBalance(idAccount)}";
        }
    }
}
