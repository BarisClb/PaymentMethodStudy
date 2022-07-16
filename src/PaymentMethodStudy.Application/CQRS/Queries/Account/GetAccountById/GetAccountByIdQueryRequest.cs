using MediatR;
using PaymentMethodStudy.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Queries.Account.GetAccountById
{
    public class GetAccountByIdQueryRequest : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
    }
}
