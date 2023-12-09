using MediatR;


namespace SeventhServers.Domain.UseCases.Servers.Ping;

public class PingServerRequestModel : IRequest<Result<PingServerResponseModel>>
{
    public string Ip { get; init; }
    public int Port { get; init; }
}
