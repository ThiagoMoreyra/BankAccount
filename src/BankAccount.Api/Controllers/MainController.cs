using BankAccount.Domain.Shared.Notify;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAccount.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifiable _notifiable;

        public MainController(INotifiable notifiable)
        {
            _notifiable = notifiable;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifiable.Notifications.Select(n => n.Message)
            });
        }

        protected bool ValidOperation()
        {
            return _notifiable.Valid;
        }

        protected void NotificarErro(string mensagem)
        {
            _notifiable.AddNotification(new Notification(mensagem));
        }
    }
}
