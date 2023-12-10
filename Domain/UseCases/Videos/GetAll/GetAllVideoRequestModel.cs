using MediatR;


namespace SeventhServers.Domain.UseCases.Videos.GetAll;

public class GetAllVideoRequestModel : IRequest<Result<GetAllVideoResponseModel>>
{
    public Guid serverId { get; set; }
}
