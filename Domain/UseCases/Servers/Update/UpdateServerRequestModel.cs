using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace SeventhServers.Domain.UseCases.Servers.Update;

public class UpdateServerRequestModel : IRequest<Result<UpdateServerResponseModel>>
{
    public Guid ServerId { get; set; }
    public string Name { get; init; }
    public string Ip { get; init; }
    public int Port { get; init; }

}
