using MassTransit;
using MediatR;
using SeventhServers.Domain;
using SeventhServers.Domain.Abstractions.FileManagement;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.Utils;
using SeventhServers.Domain.ViewModels;

namespace SeventhVideos.Domain.UseCases.Videos.GetProcess;

public class GetProcessRecycleVideoRequestHandler : IRequestHandler<GetProcessRecycleVideoRequestModel, Result<GetProcessRecycleVideoResponseModel>>
{

    public async Task<Result<GetProcessRecycleVideoResponseModel>> Handle(GetProcessRecycleVideoRequestModel request, CancellationToken cancellationToken)
    {

        return Result<GetProcessRecycleVideoResponseModel>
            .Success(new GetProcessRecycleVideoResponseModel()
            {
                IsRunning = ProcessingStatus.RecyclerIsRunning
            });
    }
}
