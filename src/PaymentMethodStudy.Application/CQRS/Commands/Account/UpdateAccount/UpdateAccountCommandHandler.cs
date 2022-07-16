using AutoMapper;
using MediatR;
using PaymentMethodStudy.Application.Exceptions;
using PaymentMethodStudy.Application.Repositories;
using PaymentMethodStudy.Application.Responses;
using PaymentMethodStudy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Commands.Account.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommandRequest, BaseResponse>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse> Handle(UpdateAccountCommandRequest request, CancellationToken cancellationToken)
        {
            PaymentMethodStudy.Domain.Entities.Account accountToUpdate = await _accountRepository.GetByIdAsync(request.Id);

            if (accountToUpdate == null)
            {
                throw new CustomNotFoundException("Account", $"Id: {request?.Id}");
            }

            #region Updating Property Control
            // Balance
            if (request?.Balance != null)
            {
                accountToUpdate.Balance += (decimal)request.Balance;
                if (accountToUpdate.Balance < 0)
                {
                    return new FailResponse("You don't have enough balance for this transaction.");
                }
            }
            // Name
            if (!String.IsNullOrEmpty(request?.Name))
            {
                //Regex.Replace(request.Name.Trim(), @"\s+", " ");
                accountToUpdate.Name = request.Name.Trim();
            }
            // Email
            if (!String.IsNullOrEmpty(request?.Email))
            {
                accountToUpdate.Email = request.Email.Trim();
            }
            // Credit Card Number
            if (!String.IsNullOrEmpty(request?.CreditCardNumber))
            {
                if (!Regex.Match(request.CreditCardNumber, @"^([0-9]{4}\s[0-9]{4}\s[0-9]{4}\s[0-9]{4})$").Success)
                {
                    return new FailResponse("Invalid Credit Card Number format.");
                }
            }
            // Credit Card Security Number
            if (!String.IsNullOrEmpty(request?.CreditCardSecurityNumber))
            {
                accountToUpdate.CreditCardSecurityNumber = request.CreditCardSecurityNumber;
            }
            // Credit Card Expiration Month
            if (!String.IsNullOrEmpty(request?.CreditCardExpirationMonth))
            {
                // Validation : New month can't be changed to a time in the Past(UtcNow).
                accountToUpdate.CreditCardExpirationMonth = request.CreditCardExpirationMonth;
            }
            // Credit Card Expiration Year
            if (!String.IsNullOrEmpty(request?.CreditCardExpirationYear))
            {
                // Validation : New year can't be changed to a time in the Past(UtcNow).
                accountToUpdate.CreditCardExpirationYear = request.CreditCardExpirationYear;
            }
            // Credit Card Status
            if (request?.CreditCardStatus != null)
            {
                accountToUpdate.CreditCardStatus = (CreditCardStatus)request.CreditCardStatus;
            }
            #endregion

            UpdateAccountCommandResponse updatedAccount = _mapper.Map<UpdateAccountCommandResponse>(await _accountRepository.UpdateAsync(accountToUpdate));

            if (updatedAccount == null)
            {
                throw new CustomDatabaseException("Account Update failed.");
            }

            return new SuccessResponse<UpdateAccountCommandResponse>(updatedAccount, "Account Update successful.", 200);
        }
    }
}
