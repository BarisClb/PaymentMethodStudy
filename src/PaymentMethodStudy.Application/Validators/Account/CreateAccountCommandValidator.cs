using FluentValidation;
using PaymentMethodStudy.Application.CQRS.Commands.Account.CreateAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Validators.Account
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommandRequest>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(account => account.Name).NotEmpty().WithMessage("Name can't be empty.");
            RuleFor(account => account.Email).NotEmpty().WithMessage("Email can't be empty.").EmailAddress().WithMessage("Wrong Email format.");
        }
    }
}
