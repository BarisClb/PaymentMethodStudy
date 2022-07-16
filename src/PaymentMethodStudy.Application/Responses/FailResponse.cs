using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Responses
{
    public class FailResponse : BaseResponse
    {
        public FailResponse(string message = "Request failed.", int httpCode = 500)
        {
            Success = false;
            Message = message;
            HttpCode = httpCode;
        }
    }
}
