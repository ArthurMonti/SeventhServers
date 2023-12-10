using MediatR;
using SeventhServers.Domain;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.UseCases.Videos.GetAll;
using SeventhServers.Domain.ViewModels;

namespace SeventhVideos.Domain.UseCases.Videos.GetAll;

public class GetAllVideoRequestHandler : IRequestHandler<GetAllVideoRequestModel, Result<GetAllVideoResponseModel>>
{
    private readonly IVideoRepository _repository;

    public GetAllVideoRequestHandler(IVideoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetAllVideoResponseModel>> Handle(GetAllVideoRequestModel request, CancellationToken cancellationToken)
    {

        var Videos = await _repository.GetAllByServerId(request.serverId);

        return Result<GetAllVideoResponseModel>
            .Success(new GetAllVideoResponseModel()
            {
                Videos = VideoView.FromEntity(Videos)
            });
    }
}
