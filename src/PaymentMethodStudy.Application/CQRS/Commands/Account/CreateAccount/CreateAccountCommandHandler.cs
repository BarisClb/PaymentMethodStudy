using AutoMapper;
using MediatR;
using PaymentMethodStudy.Application.Exceptions;
using PaymentMethodStudy.Application.Repositories;
using PaymentMethodStudy.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Commands.Account.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommandRequest, BaseResponse>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse> Handle(CreateAccountCommandRequest request, CancellationToken cancellationToken)
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
            DateTime creditCardExpirationDate = DateTime.UtcNow.AddYears(5);

            #region Old 'Credit Card Expiration Date' Method
            // This is the old Method where I used 'mmYY' format. I changed it to 'Seperate properties for month and year' so that the comparison is easier when our methods check if the Credit Card expired or not.

            //// creditCardExpirationDate = creditCardExpirationDate.Substring(0, 2) + creditCardExpirationDate.Substring(8, 2);
            // creditCardExpirationDate = string.Concat(creditCardExpirationDate.AsSpan(0, 2), creditCardExpirationDate.AsSpan(8, 2)); // => shorter version of the above method
            #endregion

            string creditCardExpirationMonth = creditCardExpirationDate.Month.ToString("D2");
            string creditCardExpirationYear = creditCardExpirationDate.Year.ToString("D2").Substring(2,2);

            // Creating the Account Entity
            PaymentMethodStudy.Domain.Entities.Account newAccountRequest = new()
            {
                Name = request.Name.Trim(),
                Email = request.Email.Trim(),
                CreditCardNumber = creditCardNumber,
                CreditCardSecurityNumber = creditCardSecurityNumber,
                CreditCardExpirationMonth = creditCardExpirationMonth,
                CreditCardExpirationYear = creditCardExpirationYear,
                Balance = 0,
                CreditCardStatus = Domain.Enums.CreditCardStatus.Active
            };

            // Adding new Account Entity to the Database
            CreateAccountCommandResponse newAccount = _mapper.Map<CreateAccountCommandResponse>(await _accountRepository.AddAsync(newAccountRequest));

            // Checking if it was successful
            if (newAccount == null || newAccount?.Id == null || newAccount?.Id == Guid.Empty)
            {
                throw new CustomDatabaseException("Account Create failed.");
            }

            // Returning response
            return new SuccessResponse<CreateAccountCommandResponse>(newAccount, "Account Create successful.", 201);
        }
    }
}
