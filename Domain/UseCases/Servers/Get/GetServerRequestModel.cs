using MediatR;
using SeventhServers.Domain.UseCases.Servers.Update;


namespace SeventhServers.Domain.UseCases.Servers.Get;

public class GetServerRequestModel : IRequest<Result<GetServerResponseModel>>
{
    public Guid serverId { get; init; }
}
