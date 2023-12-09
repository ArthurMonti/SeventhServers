using Microsoft.EntityFrameworkCore;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.Models;
using SeventhServers.Infrastructure.Data;

namespace SeventhServers.Infrastructure.Repositories
{
    public class ServerRepository : BaseRepository<Server>, IServerRepository
    {
        public ServerRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Server> GetByIPPort(string ip, int port)
        {
           return await _dataSet.FirstOrDefaultAsync(x => x.Ip == ip && x.Port == port);
        }
    }
}
