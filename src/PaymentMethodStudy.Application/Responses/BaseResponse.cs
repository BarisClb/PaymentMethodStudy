using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Responses
{
    public abstract class BaseResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public int HttpCode { get; set; }
    }
}
