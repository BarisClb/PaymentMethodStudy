using FluentValidation;
using PaymentMethodStudy.Application.CQRS.Commands.Account.UpdateAccount;
using PaymentMethodStudy.Infrastructure.FluentValidation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Infrastructure.FluentValidation.Account
{
    public class UpdateAccountCommandValidator : CustomAbstractValidator<UpdateAccountCommandRequest>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(request => request.Id).NotEmpty().WithMessage("Id can't be empty.");
            RuleFor(request => request.CreditCardNumber).CreditCard().WithMessage("Invalid Credit Card Number format."); // This accepts multiple formats, so we check the format again inside Handlers.
        }
    }
}
