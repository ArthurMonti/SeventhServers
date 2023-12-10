using MediatR;


namespace SeventhServers.Domain.UseCases.Servers.Available;

public class AvailableServerRequestModel : IRequest<Result<AvailableServerResponseModel>>
{
    public Guid ServerId { get; init; }
}
