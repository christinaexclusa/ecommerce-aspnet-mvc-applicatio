using System.Linq.Expressions;
namespace ConcertAPI.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllPageAsync(int pageIndex, int pageSize, bool includeDeleted, string orderByColumn = "Id", CancellationToken cancellationToken = default);
        Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetSearchEntityAsync(int pageIndex, int pageSize, string orderByColumn, string keyColumn, string searchText, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}