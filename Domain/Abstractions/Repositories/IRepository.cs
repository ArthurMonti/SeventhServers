using SeventhServers.Domain.DomainObjects;

namespace SeventhServers.Domain.Abstractions.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }

}
