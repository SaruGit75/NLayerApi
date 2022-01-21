using System.Linq.Expressions;

namespace NLayerApi.Core.Services
{
    public interface IService<T> where T : class
    {
        
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
