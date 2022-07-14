using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentMethodStudy.Application.CQRS.Commands.Account.CreateAccount;

namespace PaymentMethodStudy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateAccountCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
