using MediatR;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.Models;
using SeventhServers.Domain.ViewModels;

namespace SeventhServers.Domain.UseCases.Servers.Get;

public class GetServerRequestHandler : IRequestHandler<GetServerRequestModel, Result<GetServerResponseModel>>
{
    private readonly IServerRepository _repository;

    public GetServerRequestHandler(IServerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetServerResponseModel>> Handle(GetServerRequestModel request, CancellationToken cancellationToken)
    {

        var server = await _repository.GetAsync(request.serverId);

        return Result<GetServerResponseModel>
            .Success(new GetServerResponseModel()
            {
                Server = ServerView.FromEntity(server)
            });
    }
}
