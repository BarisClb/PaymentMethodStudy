using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Responses
{
    public class SuccessResponse<T> : BaseResponse
    {
        public T? Data { get; set; }
        public List<T>? Datas { get; set; }


        public SuccessResponse(List<T> datas, string message = "Request successful.", int httpCode = 200)
        {
            Success = true;
            Message = message;
            Datas = datas;
        }

        public SuccessResponse(T data, string message = "Request successful.", int httpCode = 200)
        {
            Success = true;
            Message = message;
            Data = data;
        }
    }
}
