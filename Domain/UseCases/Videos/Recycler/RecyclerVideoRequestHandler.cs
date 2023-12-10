using MassTransit;
using MediatR;
using SeventhServers.Domain;
using SeventhServers.Domain.Abstractions.FileManagement;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.ViewModels;

namespace SeventhVideos.Domain.UseCases.Videos.Recycler;

public class RecyclerVideoRequestHandler : IRequestHandler<RecyclerVideoRequestModel, Result<RecyclerVideoResponseModel>>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public RecyclerVideoRequestHandler(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Result<RecyclerVideoResponseModel>> Handle(RecyclerVideoRequestModel request, CancellationToken cancellationToken)
    {

        await _publishEndpoint.Publish(request);

        return Result<RecyclerVideoResponseModel>
            .Accepted();
    }
}
