using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Exceptions
{
    public class CustomBadRequestException : Exception
    {
        public CustomBadRequestException() : base("Bad request.")
        { }

        public CustomBadRequestException(string message) : base(message)
        { }
    }
}
