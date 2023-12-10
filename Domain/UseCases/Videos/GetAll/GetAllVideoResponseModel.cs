using SeventhServers.Domain.ViewModels;

namespace SeventhServers.Domain.UseCases.Videos.GetAll;

public class GetAllVideoResponseModel
{
    public IEnumerable<VideoView> Videos { get; init; }
}
