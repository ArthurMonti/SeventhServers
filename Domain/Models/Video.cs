using SeventhServers.Domain.DomainObjects;

namespace SeventhServers.Domain.Models
{
    public class Video : Entity
    {
        public string Description { get; set; }
        public int SizeInBytes { get; set; }
    }
}
