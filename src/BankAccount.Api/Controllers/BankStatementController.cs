using BankAccount.Api.Filter;
using BankAccount.Application.UseCases.RegisterBankStatement;
using BankAccount.Domain.Shared.Notify;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAccount.Api.Controllers
{
    [Route("api/bankstatement")]
    [ApiController]
    public class BankStatementController : MainController
    {
        private readonly IRegisterBankStatementUseCase _bankStatementUseCase;
        private readonly INotifiable notifiable;
        public BankStatementController(INotifiable notifiable, IRegisterBankStatementUseCase bankStatementUseCase)
            : base(notifiable)
        {
            _bankStatementUseCase = bankStatementUseCase;
        }

        //[ValidateModel]
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Ban)
        //{

        //}        
    }
}
