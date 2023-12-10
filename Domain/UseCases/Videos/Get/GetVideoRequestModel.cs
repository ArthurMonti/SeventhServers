using MediatR;
using SeventhServers.Domain;


namespace SeventhVideos.Domain.UseCases.Videos.Get;

public class GetVideoRequestModel : IRequest<Result<GetVideoResponseModel>>
{
    public Guid ServerId { get; init; }
    public Guid VideoId { get; init; }
}
