using SeventhServers.Domain.Models;

namespace SeventhServers.Domain.Abstractions.Repositories
{
    public interface IVideoRepository : IRepository<Video>
    {


        Task<IEnumerable<Video>> GetAllByServerId(Guid serverId);
    }
}
