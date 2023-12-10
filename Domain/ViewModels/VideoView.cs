using SeventhServers.Domain.Models;

namespace SeventhServers.Domain.ViewModels
{
    public class VideoView
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal SizeInBytes { get; set; }
        public Guid ServerId { get; set; }


        public static VideoView FromEntity(Video video)
        {
            return new VideoView()
            {
                Id = video.Id,
                Description = video.Description,
                SizeInBytes = video.SizeInBytes,
                ServerId = video.Server.Id,
            };
        }

        public static IEnumerable<VideoView> FromEntity(IEnumerable<Video> videos)
        {
            return videos.Select(s => FromEntity(s));
        }
    }
}
