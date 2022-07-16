using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Exceptions
{
    public class CustomDatabaseException : Exception
    {
        public CustomDatabaseException() : base("Something went wrong with Database actions.") 
        { }

        public CustomDatabaseException(string message) : base(message) 
        { }
    }
}
