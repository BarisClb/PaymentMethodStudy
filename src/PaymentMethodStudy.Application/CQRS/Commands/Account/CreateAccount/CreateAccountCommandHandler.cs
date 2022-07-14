using MediatR;
using PaymentMethodStudy.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Commands.Account.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommandRequest, CreateAccountCommandResponse>
    {
        readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        public async Task<CreateAccountCommandResponse> Handle(CreateAccountCommandRequest request, CancellationToken cancellationToken)
        {
            // Creating the Credit Card and Security Number
            Random random = new();
            string creditCardNumber1 = random.Next(0, 9999).ToString("D4");
            string creditCardNumber2 = random.Next(0, 9999).ToString("D4");
            string creditCardNumber3 = random.Next(0, 9999).ToString("D4");
            string creditCardNumber4 = random.Next(0, 9999).ToString("D4");

            string creditCardNumber = creditCardNumber1 + " " + creditCardNumber2 + " " + creditCardNumber3 + " " + creditCardNumber4;

            string creditCardSecurityNumber = random.Next(100, 999).ToString();

            // Creating the Credit Card Expiration Date
            string creditCardExpirationDate = DateTime.UtcNow.AddYears(5).ToString();

            // creditCardExpirationDate = creditCardExpirationDate.Substring(0, 2) + creditCardExpirationDate.Substring(8, 2);
            creditCardExpirationDate = string.Concat(creditCardExpirationDate.AsSpan(0, 2), creditCardExpirationDate.AsSpan(8, 2));


            PaymentMethodStudy.Domain.Entities.Account newAccount = new()
            {
                Name = request.Name,
                Email = request.Email,
                CreditCardNumber = creditCardNumber,
                CreditCardSecurityNumber = creditCardSecurityNumber,
                CreditCardExpirationDate = creditCardExpirationDate,
                Balance = 0,
                CreditCardStatus = Domain.Enums.CreditCardStatus.Active
            };

            await _accountRepository.AddAsync(newAccount);
            await _accountRepository.SaveChangesAsync();
            return new();
        }
    }
}
