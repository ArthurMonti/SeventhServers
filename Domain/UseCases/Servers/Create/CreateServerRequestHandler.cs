using MediatR;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.MessageErrors;
using SeventhServers.Domain.Models;

namespace SeventhServers.Domain.UseCases.Servers.Create;

public class CreateServerRequestHandler : IRequestHandler<CreateServerRequestModel, Result<CreateServerResponseModel>>
{
    private readonly IServerRepository _repository;

    public CreateServerRequestHandler(IServerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CreateServerResponseModel>> Handle(CreateServerRequestModel request, CancellationToken cancellationToken)
    {

        var createdServer = Server.New(request.Name, request.Ip, request.Port);

        var existServer = _repository.GetByIPPort(request.Ip, request.Port) == null;

        if(existServer)
        {
            return Result<CreateServerResponseModel>.Failure(ServerError.SERVER_ALREADY_EXISTS);
        }

        await _repository.InsertAsync(createdServer);
        await _repository.UnitOfWork.Commit();

        return Result<CreateServerResponseModel>
            .Created(new CreateServerResponseModel()
            {
                Id = createdServer.Id,
                Name = createdServer.Name,
                Ip = createdServer.Ip,
                Port = createdServer.Port,
                CreatedAt = createdServer.CreatedAt,
            });
    }
}
