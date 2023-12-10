using MediatR;
using SeventhServers.Domain;


namespace SeventhVideos.Domain.UseCases.Videos.Recycler;

public class RecyclerVideoRequestModel : IRequest<Result<RecyclerVideoResponseModel>>
{
    public int days { get; set; }
}
