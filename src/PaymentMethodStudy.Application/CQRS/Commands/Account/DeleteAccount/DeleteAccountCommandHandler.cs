using MediatR;
using PaymentMethodStudy.Application.Exceptions;
using PaymentMethodStudy.Application.Repositories;
using PaymentMethodStudy.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Commands.Account.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommandRequest, BaseResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public DeleteAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        public async Task<BaseResponse> Handle(DeleteAccountCommandRequest request, CancellationToken cancellationToken)
        {
            // Checking if the Account Entity exist
            Domain.Entities.Account entityToDelete = await _accountRepository.GetByIdAsync(request.Id);

            if (entityToDelete == null)
            {
                throw new CustomNotFoundException("Account", $"Id: {request.Id}");
            }

            int deletedItems = await _accountRepository.DeleteAsync(request.Id);

            if (!(deletedItems > 0))
            {
                throw new CustomDatabaseException("Account Delete failed.");
            }

            return new SuccessResponse<string>($"Id: {request.Id}", $"Account with Id: {request.Id} has been Deleted.");
        }
    }
}
