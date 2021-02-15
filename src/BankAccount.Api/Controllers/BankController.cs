using BankAccount.Api.Filter;
using BankAccount.Application.UseCases.Banks;
using BankAccount.Application.ViewModels;
using BankAccount.Domain.Shared.Notify;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAccount.Api.Controllers
{
    [Route("api/banks")]
    [ApiController]
    public class BankController : MainController
    {
        private readonly IRegisterBankUseCase _registerBankUseCase;
        private readonly INotifiable notifiable;

        public BankController(INotifiable notifiable, IRegisterBankUseCase registerBankUseCase) : base(notifiable)
        {
            _registerBankUseCase = registerBankUseCase;
        }

        [ValidateModel]
        [HttpPost]
        public IActionResult Post([FromBody] BankViewModel bankViewModel)
        {
            _registerBankUseCase.RegisterBank(bankViewModel);
            return CustomResponse(bankViewModel);
        }
    }
}
