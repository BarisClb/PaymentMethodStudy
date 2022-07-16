using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Dtos
{
    public class SortingResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool Reversed { get; set; }
        public string orderBy { get; set; }
        public string searchWord { get; set; }
        public int? TotalEntityCount { get; set; } = null;
        public int? SortedEntityCount { get; set; } = null;
    }
}
