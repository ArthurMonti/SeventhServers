using MediatR;


namespace SeventhServers.Domain.UseCases.Servers.Delete;

public class DeleteServerRequestModel : IRequest<Result<DeleteServerResponseModel>>
{
    public Guid ServerId { get; init; }
}
