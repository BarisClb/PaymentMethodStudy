using FluentValidation;
using FluentValidation.Results;
using PaymentMethodStudy.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Infrastructure.FluentValidation.Helpers
{
    public abstract class CustomAbstractValidator<T> : AbstractValidator<T>
    {
        public override ValidationResult Validate(ValidationContext<T> context)
        {
            ValidationResult validationResult = base.Validate(context);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            return validationResult;
        }
    }
}
