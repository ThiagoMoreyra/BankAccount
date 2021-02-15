using BankAccount.Api.Filter;
using BankAccount.Application.UseCases.GetBankStatement;
using BankAccount.Application.UseCases.RegisterBankStatement;
using BankAccount.Domain.Shared.Notify;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAccount.Api.Controllers
{
    [Route("api/v1/bankstatement")]
    [ApiController]
    public class BankStatementController : MainController
    {
        private readonly IGetBankStatementUseCase  _getBankStatementUseCase;
        private readonly INotifiable notifiable;
        public BankStatementController(INotifiable notifiable, IGetBankStatementUseCase getBankStatementUseCase)
            : base(notifiable)
        {
            _getBankStatementUseCase = getBankStatementUseCase;
        }

        [ValidateModel]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid idAccount)
        {
            return CustomResponse(await _getBankStatementUseCase.GetBankStatement(idAccount));
        }
    }
}
