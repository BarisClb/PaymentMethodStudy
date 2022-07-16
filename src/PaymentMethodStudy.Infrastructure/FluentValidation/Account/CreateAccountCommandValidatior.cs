using FluentValidation;
using PaymentMethodStudy.Application.CQRS.Commands.Account.CreateAccount;
using PaymentMethodStudy.Infrastructure.FluentValidation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Infrastructure.FluentValidation.Account
{
    public class CreateAccountCommandValidator : CustomAbstractValidator<CreateAccountCommandRequest>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(account => account.Name).NotEmpty().WithMessage("Name can't be empty.");
            RuleFor(account => account.Email).NotEmpty().WithMessage("Email can't be empty.").EmailAddress().WithMessage("Wrong Email format.");
        }
    }
}
