using MediatR;
using SeventhServers.Domain;


namespace SeventhVideos.Domain.UseCases.Videos.GetProcess;

public class GetProcessRecycleVideoRequestModel : IRequest<Result<GetProcessRecycleVideoResponseModel>>
{
    public int days { get; set; }
}
