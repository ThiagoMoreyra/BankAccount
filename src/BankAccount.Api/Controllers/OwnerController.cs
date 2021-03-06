﻿using BankAccount.Api.Filter;
using BankAccount.Application.UseCases.RegisterOwner;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Shared.Notify;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAccount.Api.Controllers
{
    [Route("api/v1/owners")]
    [ApiController]
    public class OwnerController : MainController
    {
        private readonly IRegisterOwnerUseCase _registerOwnerUseCase;
        private readonly INotifiable notifiable;

        public OwnerController(INotifiable notifiable, IRegisterOwnerUseCase registerOwnerUseCase) : base(notifiable)
        {
            _registerOwnerUseCase = registerOwnerUseCase;
        }

        [ValidateModel]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OwnerViewModel ownerViewModel)
        {
            var result = await _registerOwnerUseCase.RegisterOwner(ownerViewModel);
            if(result) return CustomResponse(ownerViewModel);

            return CustomResponse();
        }        
    }
}
