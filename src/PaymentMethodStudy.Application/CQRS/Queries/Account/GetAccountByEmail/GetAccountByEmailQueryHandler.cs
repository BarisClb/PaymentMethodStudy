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

namespace PaymentMethodStudy.Application.CQRS.Queries.Account.GetAccountByEmail
{
    public class GetAccountByEmailQueryHandler : IRequestHandler<GetAccountByEmailQueryRequest, BaseResponse>
    {
        IAccountRepository _accountRepository;
        IMapper _mapper;

        public GetAccountByEmailQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse> Handle(GetAccountByEmailQueryRequest request, CancellationToken cancellationToken)
        {
            PaymentMethodStudy.Domain.Entities.Account account = await _accountRepository.GetSingleAsync(account => account.Email == request.Email);

            if (account == null)
            {
                throw new CustomNotFoundException("Account", $"Email: {request?.Email}");
            }

            GetAccountByEmailQueryRequest mappedAccount = _mapper.Map<GetAccountByEmailQueryRequest>(account);

            return new SuccessResponse<GetAccountByEmailQueryRequest>(mappedAccount, "Account GetByEmail successful.", 200);
        }
    }
}
