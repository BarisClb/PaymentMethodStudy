using Microsoft.EntityFrameworkCore;
using PaymentMethodStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Persistence.Contexts
{
    public class PaymentMethodStudyDbContext : DbContext
    {
        public PaymentMethodStudyDbContext(DbContextOptions options) : base(options)
        { }


        public DbSet<Account> Accounts { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.DateCreated = DateTime.UtcNow;
                    data.Entity.DateUpdated = DateTime.UtcNow;
                }
                else if (data.State == EntityState.Modified)
                {
                    data.Entity.DateUpdated = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().HasIndex(account => account.Email).IsUnique();
        }
    }
}
