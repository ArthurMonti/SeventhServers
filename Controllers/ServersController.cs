using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeventhServers.Domain.UseCases.Servers.Available;
using SeventhServers.Domain.UseCases.Servers.Create;
using SeventhServers.Domain.UseCases.Servers.Delete;
using SeventhServers.Domain.UseCases.Servers.Get;
using SeventhServers.Domain.UseCases.Servers.GetAll;
using SeventhServers.Domain.UseCases.Servers.Ping;
using SeventhServers.Domain.UseCases.Servers.Update;
using SeventhServers.Domain.UseCases.Videos.Create;
using SeventhServers.Domain.UseCases.Videos.Delete;
using SeventhServers.Domain.UseCases.Videos.GetAll;
using SeventhVideos.Domain.UseCases.Videos.Get;
using SeventhVideos.Domain.UseCases.Videos.GetBinary;

namespace SeventhServers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : BaseController
    {
        public ServersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
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

        [HttpPut("{serverId}")]
        public async Task<IActionResult> Update([FromRoute] Guid serverId, [FromBody] UpdateServerRequestModel request, CancellationToken cancellationToken)
        {
            request.SetServerId(serverId);
            return await SendAsync<UpdateServerRequestModel, UpdateServerResponseModel>(request, cancellationToken);
        }

        [HttpPost("{serverId}/Videos")]
        public async Task<IActionResult> PostVideo([FromRoute] Guid serverId, [FromBody] CreateVideoRequestModel request, CancellationToken cancellationToken)
        {
            request.SetServerId(serverId);
            return await SendAsync<CreateVideoRequestModel, CreateVideoResponseModel>(request, cancellationToken);
        }

        [HttpGet("{serverId}/Videos")]
        public async Task<IActionResult> GetAllVideo([FromRoute] GetAllVideoRequestModel request, CancellationToken cancellationToken)
        {
            return await SendAsync<GetAllVideoRequestModel, GetAllVideoResponseModel>(request, cancellationToken);
        }

        [HttpGet("{ServerId}/Videos/{VideoId}")]
        public async Task<IActionResult> GetVideo([FromRoute] GetVideoRequestModel request, CancellationToken cancellationToken)
        {
            return await SendAsync<GetVideoRequestModel, GetVideoResponseModel>(request, cancellationToken);
        }

        [HttpGet("{ServerId}/Videos/{VideoId}/binary")]
        public async Task<IActionResult> GetVideoBinary([FromRoute] GetVideoBinaryRequestModel request, CancellationToken cancellationToken)
        {
            return await SendAsync<GetVideoBinaryRequestModel, GetVideoBinaryResponseModel>(request, cancellationToken);
        }

        [HttpDelete("{ServerId}/Videos/{VideoId}")]
        public async Task<IActionResult> DeleteVideo([FromRoute] DeleteVideoRequestModel request, CancellationToken cancellationToken)
        {
            return await SendAsync<DeleteVideoRequestModel, DeleteVideoResponseModel>(request, cancellationToken);
        }
    }
}
