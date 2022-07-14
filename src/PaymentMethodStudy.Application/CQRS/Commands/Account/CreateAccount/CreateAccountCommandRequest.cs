using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Commands.Account.CreateAccount
{
    public class CreateAccountCommandRequest : IRequest<CreateAccountCommandResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
