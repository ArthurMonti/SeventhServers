using SeventhServers.Domain.DomainObjects;

namespace SeventhServers.Domain.Models
{
    public class Video : Entity
    {
        public string Description { get; set; }
        public decimal SizeInBytes { get; set; }
        public Server Server { get; set; }
        public string File64 { get; set; }


        public static Video New(string Description, decimal SizeInBytes, Server Server, string File64)
        {
            return new()
            {
                Description = Description,
                SizeInBytes = SizeInBytes,
                Server = Server,
                File64 = File64,
                CreatedAt = DateTime.Now,
            };
        }
    }
}
