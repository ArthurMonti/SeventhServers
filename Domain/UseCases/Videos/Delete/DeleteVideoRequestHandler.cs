using MediatR;
using SeventhServers.Domain.Abstractions.FileManagement;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.Models;
using SeventhServers.Domain.ViewModels;

namespace SeventhServers.Domain.UseCases.Videos.Delete;

public class DeleteVideoRequestHandler : IRequestHandler<DeleteVideoRequestModel, Result<DeleteVideoResponseModel>>
{
    private readonly IVideoRepository _repository;
    private readonly IVideoFileManagement _fileManagement;

    public DeleteVideoRequestHandler(IVideoRepository repository, IVideoFileManagement fileManagement)
    {
        _repository = repository;
        _fileManagement = fileManagement;
    }

    public async Task<Result<DeleteVideoResponseModel>> Handle(DeleteVideoRequestModel request, CancellationToken cancellationToken)
    {

        var video = await _repository.GetAsync(request.ServerId);

        await _repository.DeleteAsync(video.Id);

        _fileManagement.DeleteFile($"{video.Server.Id}-{video.Id}");

        await _repository.UnitOfWork.Commit();


        return Result<DeleteVideoResponseModel>
            .Success(new DeleteVideoResponseModel());
    }
}
