using FluentValidation;
using PaymentMethodStudy.Application.CQRS.Queries.Account.GetAccountById;
using PaymentMethodStudy.Infrastructure.FluentValidation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Infrastructure.FluentValidation.Account
{
    public class GetAccountByIdQueryValidator : CustomAbstractValidator<GetAccountByIdQueryRequest>
    {
        public GetAccountByIdQueryValidator()
        {
            RuleFor(request => request.Id).NotEmpty().WithMessage("Id can't be empty.");
        }
    }
}
