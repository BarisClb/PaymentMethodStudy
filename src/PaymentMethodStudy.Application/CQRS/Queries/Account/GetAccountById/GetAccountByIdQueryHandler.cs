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

namespace PaymentMethodStudy.Application.CQRS.Queries.Account.GetAccountById
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQueryRequest, BaseResponse>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountByIdQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse> Handle(GetAccountByIdQueryRequest request, CancellationToken cancellationToken)
        {
            PaymentMethodStudy.Domain.Entities.Account account = await _accountRepository.GetByIdAsync(request.Id);

            if (account == null)
            {
                throw new CustomNotFoundException("Account", $"Id: {request?.Id}");
            }

            GetAccountByIdQueryResponse mappedAccount = _mapper.Map<GetAccountByIdQueryResponse>(account);

            return new SuccessResponse<GetAccountByIdQueryResponse>(mappedAccount, "Account GetById successful", 200);
        }
    }
}
