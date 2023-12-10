namespace SeventhServers.Domain.UseCases.Videos.Create;

public class CreateVideoResponseModel
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public string Description { get; set; }
    public Guid ServerId { get; set; }
    public decimal SizeInBytes { get; set; }
}
