using MediatR;
using SeventhServers.Domain.Models;


namespace SeventhServers.Domain.UseCases.Videos.Create;

public class CreateVideoRequestModel : IRequest<Result<CreateVideoResponseModel>>
{
    public string Description { get; init; }
    public Guid ServerId { get; private set; }
    public string File64 { get; init; }

    public void SetServerId(Guid serverId) => ServerId = serverId;
}
