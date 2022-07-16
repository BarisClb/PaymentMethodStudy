using AutoMapper;
using MediatR;
using PaymentMethodStudy.Application.Dtos;
using PaymentMethodStudy.Application.Exceptions;
using PaymentMethodStudy.Application.Repositories;
using PaymentMethodStudy.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Queries.Account.GetAllAccount
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQueryRequest, BaseResponse>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountsQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse> Handle(GetAccountsQueryRequest request, CancellationToken cancellationToken)
        {
            // First of all, we prepare the list.
            IList<Domain.Entities.Account> accountList = _accountRepository.Get(tracking: false).ToList();
            int totalEntityCount = accountList.Count;

            if (accountList == null)
            {
                throw new CustomDatabaseException("AccountList get failed.");
            }

            // Now we check if sortValues has a 'SearchWord' and if true, we sort the list that contains that word.
            if (!String.IsNullOrEmpty(request?.SortingData?.SearchWord))
                accountList = accountList.AsQueryable().Where(account => account.Name.Contains(request.SortingData.SearchWord)).ToList();

            // Order By
            if (String.IsNullOrEmpty(request?.SortingData?.OrderBy))
            {
                switch (request?.SortingData?.OrderBy)
                {
                    case "Name":
                        accountList = accountList.AsQueryable().OrderBy(account => account.Name).ToList();
                        break;
                    case "Email":
                        accountList = accountList.AsQueryable().OrderBy(account => account.Email).ToList();
                        break;
                    default:
                        request.SortingData.OrderBy = "DateCreated"; // Fall back to Default 'OrderBy DateCreated or Id'
                        break;
                }
            }
            else // If its an empty string, it will fall here. We reset this to show it as an info in Response.
            {
                request.SortingData.OrderBy = "DateCreated"; // Fall back to Default 'OrderBy DateCreated or Id'
            }

            // Reverse?
            if (request.SortingData.Reversed)
            {
                accountList = accountList.Reverse().ToList();
            }

            // Pagination and Mapping

            // If PageSize is 0, get the whole list. Basically, a GetAll() function.
            if (request.SortingData.PageSize == 0)
                request.SortingData.PageSize = accountList.Count;

            List<GetAccountsQueryResponse> mappedAccountList = accountList.Skip((request.SortingData.PageNumber - 1) * request.SortingData.PageSize).Take(request.SortingData.PageSize).Select(entity => _mapper.Map<GetAccountsQueryResponse>(entity)).ToList();

            SortingResponse sortingResponse = _mapper.Map<SortingResponse>(request.SortingData);
            sortingResponse.TotalEntityCount = totalEntityCount;
            sortingResponse.SortedEntityCount = mappedAccountList.Count;

            return new SortedResponse<GetAccountsQueryResponse, SortingResponse>(mappedAccountList, sortingResponse, "Account Get successful.", 200);
        }
    }
}
