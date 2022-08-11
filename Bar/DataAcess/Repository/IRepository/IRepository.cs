using System.Linq.Expressions;

namespace Bar.DataAcess.Repository.IRepository
{
    public interface Repository<T> where T : class
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        Task SaveAsync();
    }
}
