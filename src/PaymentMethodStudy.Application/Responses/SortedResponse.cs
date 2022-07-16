using PaymentMethodStudy.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Responses
{
    public class SortedResponse<T, G> : SuccessResponse<T>
    {
        public G SortingData { get; set; }


        public SortedResponse(List<T> datas, G sortingData, string message = "Request successful.", int httpCode = 200) : base(datas, message, httpCode)
        {
            SortingData = sortingData;
        }
    }
}
