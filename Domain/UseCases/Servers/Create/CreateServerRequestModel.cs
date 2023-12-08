using MediatR;


namespace SeventhServers.Domain.UseCases.Servers.Create;

public class CreateServerRequestModel : IRequest<Result<CreateServerResponseModel>>
{
    public string Name { get; init; }
    public string Ip { get; init; }
    public int Port { get; init; }
}
