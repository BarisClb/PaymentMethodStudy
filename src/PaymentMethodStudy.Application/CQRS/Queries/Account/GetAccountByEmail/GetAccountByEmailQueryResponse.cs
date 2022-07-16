using PaymentMethodStudy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Queries.Account.GetAccountByEmail
{
    public class GetAccountByEmailQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardSecurityNumber { get; set; }
        public byte CreditCardExpirationMonth { get; set; }
        public byte CreditCardExpirationYear { get; set; }
        public decimal Balance { get; set; }
        public CreditCardStatus CreditCardStatus { get; set; }
    }
}
