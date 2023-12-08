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
    }
}
