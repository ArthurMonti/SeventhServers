using Microsoft.EntityFrameworkCore;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.DomainObjects;
using SeventhServers.Infrastructure.Data;

namespace SeventhServers.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> _dataSet;

        public IUnitOfWork UnitOfWork => _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _dataSet.SingleOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await _dataSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            var result = await _dataSet.SingleOrDefaultAsync(x => x.Id == entity.Id);
            if (result is null)
                ArgumentNullException.ThrowIfNull(result, typeof(T).GetType().Name);

            _context.Entry(result).CurrentValues.SetValues(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var result = await _dataSet.SingleOrDefaultAsync(x => x.Id == id);
            if (result is null)
                ArgumentNullException.ThrowIfNull(result, typeof(T).GetType().Name);

            _dataSet.Remove(result);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
