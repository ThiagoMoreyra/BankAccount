using BankAccount.Api.Filter;
using BankAccount.Application.UseCases.Banks;
using BankAccount.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAccount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IRegisterBankUseCase _registerBankUseCase;
        public BankController(IRegisterBankUseCase registerBankUseCase)
        {
            _registerBankUseCase = registerBankUseCase;
        }

        [ValidateModel]
        [HttpPost]
        public void Post([FromBody] BankViewModel bankViewModel)
        {
            _registerBankUseCase.RegisterBank(bankViewModel);
        }
    }
}
