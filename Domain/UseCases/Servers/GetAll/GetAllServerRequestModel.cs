using MediatR;


namespace SeventhServers.Domain.UseCases.Servers.GetAll;

public class GetAllServerRequestModel : IRequest<Result<GetAllServerResponseModel>>
{
    public string Name { get; init; }
    public string Ip { get; init; }
    public int Port { get; init; }
}
