using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Exceptions
{
    public class CustomNotFoundException : Exception
    {
        public CustomNotFoundException() : base("Request was not found.")
        { }

        public CustomNotFoundException(string message) : base(message)
        { }

        public CustomNotFoundException(string entity, string props) : base($"Entity: {entity} with {props} was not found.")
        { }
    }
}
