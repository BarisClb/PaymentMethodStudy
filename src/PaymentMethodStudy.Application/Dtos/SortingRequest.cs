using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Dtos
{
    public class SortingRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool Reversed { get; set; } = false;


        private string orderBy = "DateCreated";
        public string OrderBy { get => orderBy; set => orderBy = string.IsNullOrWhiteSpace(value) ? "DateCreated" : value; }

        private string searchWord = "";
        public string SearchWord { get => searchWord; set => searchWord = string.IsNullOrWhiteSpace(value) ? "" : value; }
    }
}
