using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaymentMethodStudy.Application.Repositories;
using PaymentMethodStudy.Persistence.Contexts;
using PaymentMethodStudy.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Persistence
{
    public static class ServiceRegistration
    {
        public static void ImplementPersistenceServices(this IServiceCollection services, string connectionString)
        {
            //// Service Connection

            // Sql Server Connection
            services.AddDbContext<PaymentMethodStudyDbContext>(options => options.UseSqlServer(connectionString));

            //// Dependency Injection

            // Account
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
