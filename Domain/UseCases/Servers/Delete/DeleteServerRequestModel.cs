using MediatR;


namespace SeventhServers.Domain.UseCases.Servers.Delete;

public class DeleteServerRequestModel : IRequest<Result<DeleteServerResponseModel>>
{
    public Guid serverId { get; init; }
}
