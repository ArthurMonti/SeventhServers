using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeventhServers.Domain.UseCases.Servers.Available;
using SeventhServers.Domain.UseCases.Servers.Create;
using SeventhServers.Domain.UseCases.Servers.Delete;
using SeventhServers.Domain.UseCases.Servers.Get;
using SeventhServers.Domain.UseCases.Servers.GetAll;
using SeventhServers.Domain.UseCases.Servers.Ping;
using SeventhServers.Domain.UseCases.Servers.Update;
using System.Net.NetworkInformation;

namespace SeventhServers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : BaseController
    {
        public ServersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("/api/server")]
        public async Task<IActionResult> Post([FromBody] CreateServerRequestModel request, CancellationToken cancellationToken)
        {
            return await SendAsync<CreateServerRequestModel, CreateServerResponseModel>(request, cancellationToken);
        }

        [HttpGet("{serverId}")]
        public async Task<IActionResult> Get([FromRoute] GetServerRequestModel request, CancellationToken cancellationToken)
        {
            return await SendAsync<GetServerRequestModel, GetServerResponseModel>(request, cancellationToken);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var request = new GetAllServerRequestModel();
            return await SendAsync<GetAllServerRequestModel, GetAllServerResponseModel>(request, cancellationToken);
        }

        [HttpGet("available/{serverId}")]
        public async Task<IActionResult> GetAvailable([FromRoute] AvailableServerRequestModel request, CancellationToken cancellationToken)
        {
            return await SendAsync<AvailableServerRequestModel, AvailableServerResponseModel>(request, cancellationToken);
        }

        [HttpGet("Ping")]
        public async Task<IActionResult> Ping([FromQuery] PingServerRequestModel request, CancellationToken cancellationToken)
        {
            return await SendAsync<PingServerRequestModel,PingServerResponseModel>(request,cancellationToken);
        }

        [HttpDelete("{serverId}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteServerRequestModel request, CancellationToken cancellationToken)
        {
            return await SendAsync<DeleteServerRequestModel, DeleteServerResponseModel>(request, cancellationToken);
        }

        [HttpPut("{serverId")]
        public async Task<IActionResult> Delete([FromRoute] Guid serverId, [FromBody] UpdateServerRequestModel request, CancellationToken cancellationToken)
        {
            request.ServerId = serverId;
            return await SendAsync<UpdateServerRequestModel, UpdateServerResponseModel>(request, cancellationToken);
        }
    }
}
