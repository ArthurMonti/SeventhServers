using SeventhServers.Domain.DomainObjects;

namespace SeventhServers.Domain.Models
{
    public class Server : Entity
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }


        public static Server New(string Name, string Ip, int Port)
        {
            return new()
            {
                Name = Name,
                Ip = Ip,
                Port = Port,
                CreatedAt = DateTime.Now,
            };
        }
    }
}
