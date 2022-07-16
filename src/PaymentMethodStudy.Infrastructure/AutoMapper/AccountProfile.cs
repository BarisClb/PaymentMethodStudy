using AutoMapper;
using PaymentMethodStudy.Application.CQRS.Commands.Account.CreateAccount;
using PaymentMethodStudy.Application.CQRS.Commands.Account.UpdateAccount;
using PaymentMethodStudy.Application.CQRS.Queries.Account.GetAccountByEmail;
using PaymentMethodStudy.Application.CQRS.Queries.Account.GetAccountById;
using PaymentMethodStudy.Application.CQRS.Queries.Account.GetAllAccount;
using PaymentMethodStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Infrastructure.AutoMapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            //// Read

            // Get
            CreateMap<Account, GetAccountsQueryRequest>().ReverseMap();
            CreateMap<Account, GetAccountsQueryResponse>().ReverseMap();
            // GetById
            CreateMap<Account, GetAccountByIdQueryRequest>().ReverseMap();
            CreateMap<Account, GetAccountByIdQueryResponse>().ReverseMap();
            // GetBy Email
            CreateMap<Account, GetAccountByEmailQueryRequest>().ReverseMap();
            CreateMap<Account, GetAccountByEmailQueryResponse>().ReverseMap();

            // Create
            CreateMap<Account, CreateAccountCommandRequest>().ReverseMap();
            CreateMap<Account, CreateAccountCommandResponse>().ReverseMap();

            // Update
            CreateMap<Account, UpdateAccountCommandRequest>().ReverseMap();
            CreateMap<Account, UpdateAccountCommandResponse>().ReverseMap();
        }
    }
}
