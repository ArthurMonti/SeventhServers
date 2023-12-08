namespace SeventhServers.Domain.UseCases.Servers.Create;

public class CreateServerResponseModel
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public string Ip { get; set; }
    public int Port { get; set; }
}
