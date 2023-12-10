using MediatR;
using SeventhServers.Domain;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.ViewModels;

namespace SeventhVideos.Domain.UseCases.Videos.Get;

public class GetVideoRequestHandler : IRequestHandler<GetVideoRequestModel, Result<GetVideoResponseModel>>
{
    private readonly IVideoRepository _repository;

    public GetVideoRequestHandler(IVideoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetVideoResponseModel>> Handle(GetVideoRequestModel request, CancellationToken cancellationToken)
    {
        var Video = await _repository.GetAsync(request.VideoId);

        return Result<GetVideoResponseModel>
            .Success(new GetVideoResponseModel()
            {
                Video = VideoView.FromEntity(Video)
            });
    }
}
