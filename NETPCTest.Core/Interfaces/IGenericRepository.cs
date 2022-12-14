using System.Linq.Expressions;
namespace NETPCTest.Core.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
        IQueryable<TEntity> GetWithEntity<TProperty, TPropertyTwo>(
            Expression<Func<TEntity, TProperty>> includeEntityOne,
            Expression<Func<TEntity, TPropertyTwo>>? includeEntityTwo);
    }
}
