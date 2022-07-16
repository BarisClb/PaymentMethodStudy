using PaymentMethodStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Application.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        // Read
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true);
        Task<TEntity> GetByIdAsync(Guid id, bool tracking = true);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null, bool tracking = true);

        // Create / Update / Delete
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);

        int Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        int Delete(Guid id);
        Task<int> DeleteAsync(Guid id);
        int DeleteRange(IEnumerable<TEntity> entities);
        Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities);
        int DeleteWhere(Expression<Func<TEntity, bool>> predicate);
        Task<int> DeleteWhereAsync(Expression<Func<TEntity, bool>> predicate);


        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
