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
    }
}
