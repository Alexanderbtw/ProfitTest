using System.Linq.Expressions;

namespace ProfitTest.Core.Interfaces.DAL
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<T?> GetAsync(Guid id, CancellationToken token);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken token);
        Task<T?> FindAsync(Expression<Func<T, bool>> expression, CancellationToken token);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression, CancellationToken token);
        Task<T> AddAsync(T entity, CancellationToken token);
        Task<bool> RemoveAsync(Guid id, CancellationToken token);
        T Update(T entity);
    }
}
