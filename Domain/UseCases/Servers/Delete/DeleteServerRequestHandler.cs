using MediatR;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.MessageErrors;
using SeventhServers.Domain.Models;
using SeventhServers.Domain.UseCases.Servers.Available;
using SeventhServers.Domain.ViewModels;

namespace SeventhServers.Domain.UseCases.Servers.Delete;

public class DeleteServerRequestHandler : IRequestHandler<DeleteServerRequestModel, Result<DeleteServerResponseModel>>
{
    private readonly IServerRepository _repository;

    public DeleteServerRequestHandler(IServerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<DeleteServerResponseModel>> Handle(DeleteServerRequestModel request, CancellationToken cancellationToken)
    {

        var server = await _repository.GetAsync(request.ServerId);

        if(server == null || server.DeletedAt != null)
        {
            return Result<DeleteServerResponseModel>.Failure(ServerError.SERVER_NOT_EXISTS);
        }

        server.Delete();
        await _repository.UpdateAsync(server);
        await _repository.UnitOfWork.Commit();

        return Result<DeleteServerResponseModel>
            .Success(new DeleteServerResponseModel());
    }
}
