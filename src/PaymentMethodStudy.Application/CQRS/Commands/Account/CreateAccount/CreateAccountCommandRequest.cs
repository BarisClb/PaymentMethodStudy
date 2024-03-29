﻿using MediatR;
using PaymentMethodStudy.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.CQRS.Commands.Account.CreateAccount
{
    public class CreateAccountCommandRequest : IRequest<BaseResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
