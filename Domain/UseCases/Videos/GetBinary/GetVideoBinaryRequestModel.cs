using MediatR;
using SeventhServers.Domain;


namespace SeventhVideos.Domain.UseCases.Videos.GetBinary;

public class GetVideoBinaryRequestModel : IRequest<Result<GetVideoBinaryResponseModel>>
{
    public Guid ServerId { get; init; }
    public Guid VideoId { get; init; }
}
