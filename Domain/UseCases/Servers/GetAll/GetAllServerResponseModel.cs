using SeventhServers.Domain.ViewModels;

namespace SeventhServers.Domain.UseCases.Servers.GetAll;

public class GetAllServerResponseModel
{
    public IEnumerable<ServerView> Servers { get; init; }
}
