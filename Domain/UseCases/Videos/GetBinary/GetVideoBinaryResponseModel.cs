using SeventhServers.Domain.ViewModels;

namespace SeventhVideos.Domain.UseCases.Videos.GetBinary;

public class GetVideoBinaryResponseModel
{
    public byte[] Video { get; init; }
}
