using PaymentMethodStudy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardSecurityNumber { get; set; }
        public string CreditCardExpirationDate { get; set; }
        public decimal Balance { get; set; }
        public CreditCardStatus CreditCardStatus { get; set; }
    }
}
