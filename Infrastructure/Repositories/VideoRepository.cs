using Microsoft.EntityFrameworkCore;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.Models;
using SeventhServers.Infrastructure.Data;

namespace SeventhServers.Infrastructure.Repositories
{
    public class VideoRepository : BaseRepository<Video>, IVideoRepository
    {
        public VideoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Video>> GetAllByServerId(Guid serverId)
        {
           return await _dataSet.Include(x => x.Server).Where(x => x.Server.Id == serverId).ToListAsync();
        }

        public async Task<IEnumerable<Video>> GetAllCreatedLastDays(int days)
        {
            var date = DateTime.Now.AddDays(-days);

            return await _dataSet.Include(x => x.Server).Where(x => x.CreatedAt > date).ToListAsync();
        }

        public new async Task<Video> GetAsync(Guid id)
        {
            return await _dataSet.Include(x => x.Server).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
