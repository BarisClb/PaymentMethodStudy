using FluentValidation;
using PaymentMethodStudy.Application.CQRS.Queries.Account.GetAccountByEmail;
using PaymentMethodStudy.Infrastructure.FluentValidation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Infrastructure.FluentValidation.Account
{
    public class GetAccountByEmailValidator : CustomAbstractValidator<GetAccountByEmailQueryRequest>
    {
        public GetAccountByEmailValidator()
        {
            RuleFor(account => account.Email).NotEmpty().WithMessage("Email can't be empty.").EmailAddress().WithMessage("Wrong Email format.");
        }
    }
}
