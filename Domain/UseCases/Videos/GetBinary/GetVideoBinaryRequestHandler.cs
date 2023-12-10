using MediatR;
using SeventhServers.Domain;
using SeventhServers.Domain.Abstractions.FileManagement;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.ViewModels;

namespace SeventhVideos.Domain.UseCases.Videos.GetBinary;

public class GetVideoBinaryRequestHandler : IRequestHandler<GetVideoBinaryRequestModel, Result<GetVideoBinaryResponseModel>>
{
    private readonly IVideoRepository _repository;
    private readonly IVideoFileManagement _fileManagement;

    public GetVideoBinaryRequestHandler(IVideoRepository repository, IVideoFileManagement fileManagement)
    {
        _repository = repository;
        _fileManagement = fileManagement;
    }

    public async Task<Result<GetVideoBinaryResponseModel>> Handle(GetVideoBinaryRequestModel request, CancellationToken cancellationToken)
    {
        var video = await _repository.GetAsync(request.VideoId);

        var bytes = await _fileManagement.GetBase64($"{video.Server.Id}-{video.Id}");


        return Result<GetVideoBinaryResponseModel>
            .Success(new GetVideoBinaryResponseModel()
            {
                Video = bytes
            });
    }
}
