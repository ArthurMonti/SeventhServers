using MediatR;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.Models;
using SeventhServers.Domain.ViewModels;

namespace SeventhServers.Domain.UseCases.Servers.Available;

public class AvailableServerRequestHandler : IRequestHandler<AvailableServerRequestModel, Result<AvailableServerResponseModel>>
{
    private readonly IServerRepository _repository;

    public AvailableServerRequestHandler(IServerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AvailableServerResponseModel>> Handle(AvailableServerRequestModel request, CancellationToken cancellationToken)
    {

        var server = await _repository.GetAsync(request.ServerId);

        return Result<AvailableServerResponseModel>
            .Success(new AvailableServerResponseModel()
            {
                Available = server.DeletedAt == null
            });
    }
}
