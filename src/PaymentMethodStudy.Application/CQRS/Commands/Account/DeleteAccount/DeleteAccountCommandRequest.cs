using MediatR;
using PaymentMethodStudy.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Commands.Account.DeleteAccount
{
    public class DeleteAccountCommandRequest : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
    }
}
