using SeventhServers.Domain.Models;

namespace SeventhServers.Domain.ViewModels
{
    public class ServerView
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Ip { get; init; }
        public int Port { get; init; }


        public static ServerView FromEntity(Server server)
        {
            return new ServerView()
            {
                Id = server.Id,
                Name = server.Name,
                Ip = server.Ip,
                Port = server.Port,
            };
        }

        public static IEnumerable<ServerView> FromEntity(IEnumerable<Server> servers)
        {
            return servers.Select(s => FromEntity(s));
        }
    }
}
