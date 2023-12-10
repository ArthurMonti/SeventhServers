using MediatR;


namespace SeventhServers.Domain.UseCases.Videos.Delete;

public class DeleteVideoRequestModel : IRequest<Result<DeleteVideoResponseModel>>
{
    public Guid ServerId { get; init; }
    public Guid VideoId { get; init; }  
}
