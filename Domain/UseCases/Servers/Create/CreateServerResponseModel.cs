namespace SeventhServers.Domain.UseCases.Servers.Create;

public class CreateServerResponseModel
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public string Name { get; init; }
    public string Ip { get; init; }
    public int Port { get; init; }
}
