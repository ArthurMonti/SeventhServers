using MediatR;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.Models;
using SeventhServers.Domain.ViewModels;

namespace SeventhServers.Domain.UseCases.Servers.Update;

public class UpdateServerRequestHandler : IRequestHandler<UpdateServerRequestModel, Result<UpdateServerResponseModel>>
{
    private readonly IServerRepository _repository;

    public UpdateServerRequestHandler(IServerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<UpdateServerResponseModel>> Handle(UpdateServerRequestModel request, CancellationToken cancellationToken)
    {

        var server = await _repository.GetAsync(request.ServerId);

        server.Update(request.Name,request.Ip,request.Port);

        await _repository.UpdateAsync(server);
        await _repository.UnitOfWork.Commit();

        return Result<UpdateServerResponseModel>
            .Success(new UpdateServerResponseModel()
            {
                Server = ServerView.FromEntity(server)
            });
    }
}
