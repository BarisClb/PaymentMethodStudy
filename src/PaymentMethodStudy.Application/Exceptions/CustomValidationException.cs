using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        // public IDictionary<string, string[]> Failures { get; }
        public IList<string> Failures { get; }

        public CustomValidationException() : base("One or more Validation Failures have occurred.")
        {
            // Failures = new Dictionary<string, string[]>();
            Failures = new List<String>();
        }

        //// This creates a problem when serializing, no double quotes inside strings. So C# uses escape character like this: "[\"Email\": \"Email can't be empty.\"]"
        //public CustomValidationException(List<ValidationFailure> failures) : this()
        //{
        //    IEnumerable<string> propertyNames = failures
        //        .Select(e => e.PropertyName)
        //        .Distinct();

        //    foreach (var propertyName in propertyNames)
        //    {
        //        var propertyFailures = failures
        //            .Where(e => e.PropertyName == propertyName)
        //            .Select(e => e.ErrorMessage)
        //            .ToArray();

        //        Failures.Add(propertyName, propertyFailures);
        //    }
        //}

        public CustomValidationException(List<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Failures.Add($"{failure.PropertyName}: {failure.ErrorMessage}");
            }
        }
    }
}
