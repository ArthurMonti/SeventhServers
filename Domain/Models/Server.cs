using SeventhServers.Domain.DomainObjects;

namespace SeventhServers.Domain.Models
{
    public class Server : Entity
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
    }
}
