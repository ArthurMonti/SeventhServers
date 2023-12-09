using MediatR;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.Models;
using SeventhServers.Domain.ViewModels;

namespace SeventhServers.Domain.UseCases.Servers.GetAll;

public class GetAllServerRequestHandler : IRequestHandler<GetAllServerRequestModel, Result<GetAllServerResponseModel>>
{
    private readonly IServerRepository _repository;

    public GetAllServerRequestHandler(IServerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetAllServerResponseModel>> Handle(GetAllServerRequestModel request, CancellationToken cancellationToken)
    {

        var servers = await _repository.GetAllAsync();

        return Result<GetAllServerResponseModel>
            .Success(new GetAllServerResponseModel()
            {
                Servers = ServerView.FromEntity(servers)
            });
    }
}
