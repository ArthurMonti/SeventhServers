using MediatR;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.Models;
using SeventhServers.Domain.ViewModels;

namespace SeventhServers.Domain.UseCases.Servers.Ping;

public class PingServerRequestHandler : IRequestHandler<PingServerRequestModel, Result<PingServerResponseModel>>
{
    private readonly IServerRepository _repository;

    public PingServerRequestHandler(IServerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PingServerResponseModel>> Handle(PingServerRequestModel request, CancellationToken cancellationToken)
    {

        var server = await _repository.GetByIPPort(request.Ip, request.Port);

        if(server == null || server.DeletedAt != null)
        {
            return Result<PingServerResponseModel>.NoContent();
        }

        return Result<PingServerResponseModel>
            .Success(new PingServerResponseModel()
            {
                Name = server.Name
            });
    }
}
