using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PaymentMethodStudy.Application.CQRS.Commands.Account.CreateAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application
{
    public static class ServiceRegistration
    {
        public static void ImplementApplicationServices(this IServiceCollection services)
        {
            // services.AddMediatR(typeof(CreateAccountCommandHandler));
            // services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CreateAccountCommandHandler).GetTypeInfo().Assembly);
        }
    }
}
