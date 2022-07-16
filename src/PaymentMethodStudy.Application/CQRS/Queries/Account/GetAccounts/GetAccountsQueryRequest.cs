using MediatR;
using PaymentMethodStudy.Application.Dtos;
using PaymentMethodStudy.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Queries.Account.GetAllAccount
{
    public class GetAccountsQueryRequest : IRequest<BaseResponse>
    {
        public SortingRequest SortingData { get; set; } = new SortingRequest();
    }
}
