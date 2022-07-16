using MediatR;
using PaymentMethodStudy.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Queries.Account.GetAccountByEmail
{
    public class GetAccountByEmailQueryRequest : IRequest<BaseResponse>
    {
        public string Email { get; set; }
    }
}
