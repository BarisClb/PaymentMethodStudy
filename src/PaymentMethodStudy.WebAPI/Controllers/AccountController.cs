using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentMethodStudy.Application.CQRS.Commands.Account.CreateAccount;
using PaymentMethodStudy.Application.CQRS.Commands.Account.DeleteAccount;
using PaymentMethodStudy.Application.CQRS.Commands.Account.UpdateAccount;
using PaymentMethodStudy.Application.CQRS.Queries.Account.GetAccountByEmail;
using PaymentMethodStudy.Application.CQRS.Queries.Account.GetAccountById;
using PaymentMethodStudy.Application.CQRS.Queries.Account.GetAllAccount;

namespace PaymentMethodStudy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAccounts")]
        public async Task<IActionResult> Get([FromQuery] GetAccountsQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("GetAccountById")]
        public async Task<IActionResult> GetById([FromQuery] GetAccountByIdQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("GetAccountByEmail")]
        public async Task<IActionResult> GetByEmail([FromQuery] GetAccountByEmailQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> Create(CreateAccountCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> Update(UpdateAccountCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> Delete(DeleteAccountCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
