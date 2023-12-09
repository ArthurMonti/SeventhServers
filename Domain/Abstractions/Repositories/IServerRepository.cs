using SeventhServers.Domain.Models;

namespace SeventhServers.Domain.Abstractions.Repositories
{
    public interface IServerRepository : IRepository<Server>
    {

        Task<Server> GetByIPPort(string ip, int port);
    }
}
