using FluentValidation;
using PaymentMethodStudy.Application.CQRS.Commands.Account.DeleteAccount;
using PaymentMethodStudy.Infrastructure.FluentValidation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Infrastructure.FluentValidation.Account
{
    public class DeleteAccountCommandValidator : CustomAbstractValidator<DeleteAccountCommandRequest>
    {
        public DeleteAccountCommandValidator()
        {
            RuleFor(request => request.Id).NotEmpty().WithMessage("Id can't be empty.");
        }
    }
}
