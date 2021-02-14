﻿using BankAccount.Api.Filter;
using BankAccount.Application.UseCases.Accounts;
using BankAccount.Application.UseCases.GetAccount;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Shared.Notify;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAccount.Api.Controllers
{
    [Route("v1/accounts")]
    [ApiController]
    public class AccountController : MainController
    {
        private readonly INotifiable _notifiable;
        private readonly IOpenAccountUseCase _accountUseCase;
        private readonly IGetAccountUseCase _getAccountUseCase;
        public AccountController(INotifiable notifiable, IOpenAccountUseCase accountUseCase, IGetAccountUseCase getAccountUseCase)
            : base(notifiable)
        {
            _notifiable = notifiable;
            _accountUseCase = accountUseCase;
            _getAccountUseCase = getAccountUseCase;
        }

        [ValidateModel]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountViewModel accountViewModel)
        {
            _accountUseCase.RegisterAccount(accountViewModel);
            return CustomResponse(accountViewModel);
        }

        [ValidateModel]
        [HttpGet("avaliable-account")]
        public async Task<IActionResult> Get([FromQuery] double fee, [FromQuery] Guid idAccount)
        {
            return CustomResponse(_getAccountUseCase.GetAvaliableAccount(fee, idAccount));
        }
    }
}
