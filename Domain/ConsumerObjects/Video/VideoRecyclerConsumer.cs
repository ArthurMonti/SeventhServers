using MassTransit;
using SeventhServers.Domain.Abstractions.FileManagement;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.Utils;
using SeventhVideos.Domain.UseCases.Videos.Recycler;

namespace SeventhServers.Domain.ConsumerObjects.Video
{
    public class VideoRecyclerConsumer : IConsumer<RecyclerVideoRequestModel>
    {
        private readonly IVideoRepository _repository;
        private readonly IVideoFileManagement _fileManagement;

        public VideoRecyclerConsumer(IVideoRepository repository, IVideoFileManagement fileManagement)
        {
            _repository = repository;
            _fileManagement = fileManagement;
        }

        public async Task Consume(ConsumeContext<RecyclerVideoRequestModel> context)
        {
            ProcessingStatus.RecyclerIsRunning = true;

            var message = context.Message;

            var videos = await _repository.GetAllCreatedLastDays(message.days);

            foreach(var video in videos)
            {
                await _repository.DeleteAsync(video.Id);

                _fileManagement.DeleteFile($"{video.Server.Id}-{video.Id}");
                await _repository.UnitOfWork.Commit();
            }

            ProcessingStatus.RecyclerIsRunning = false;
        }
    }
}
