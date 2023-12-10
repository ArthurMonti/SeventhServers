using MediatR;
using SeventhServers.Domain.Abstractions.FileManagement;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.Models;
using SeventhServers.Domain.Utils;

namespace SeventhServers.Domain.UseCases.Videos.Create;

public class CreateVideoRequestHandler : IRequestHandler<CreateVideoRequestModel, Result<CreateVideoResponseModel>>
{
    private readonly IVideoRepository _repository;
    private readonly IServerRepository _serverRepository;
    private readonly IVideoFileManagement _fileManagement;

    public CreateVideoRequestHandler(IVideoRepository repository, IServerRepository serverRepository, IVideoFileManagement fileManagement)
    {
        _repository = repository;
        _serverRepository = serverRepository;
        _fileManagement = fileManagement;
    }

    public async Task<Result<CreateVideoResponseModel>> Handle(CreateVideoRequestModel request, CancellationToken cancellationToken)
    {
        var server = await _serverRepository.GetAsync(request.ServerId);


        var fileBytes = Base64Convert.ToBytes(request.File64);
        var createdVideo = Video.New(request.Description, fileBytes.LongLength, server, request.File64);

        await _repository.InsertAsync(createdVideo);
        await _fileManagement.SaveBase64(fileBytes, $"{createdVideo.Server.Id}-{createdVideo.Id}");
        await _repository.UnitOfWork.Commit();

        return Result<CreateVideoResponseModel>
            .Created(new CreateVideoResponseModel()
            {
                Id = createdVideo.Id,
                Description = createdVideo.Description,
                ServerId = createdVideo.Server.Id,
                SizeInBytes = createdVideo.SizeInBytes,
                CreatedAt = createdVideo.CreatedAt,
            });
    }
}
