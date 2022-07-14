using PaymentMethodStudy.Application.Repositories;
using PaymentMethodStudy.Domain.Entities;
using PaymentMethodStudy.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Persistence.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(PaymentMethodStudyDbContext context) : base(context)
        { }
    }
}
