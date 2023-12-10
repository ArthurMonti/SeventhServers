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
using SeventhVideos.Domain.UseCases.Videos.Recycler;

namespace SeventhServers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecycleController : BaseController
    {
        public RecycleController(IMediator mediator) : base(mediator)
        {
        }

        [HttpDelete("recycler/process/{days}​")]
        public async Task<IActionResult> RecyclerVideos([FromRoute] RecyclerVideoRequestModel request, CancellationToken cancellationToken)
        {
            return await SendAsync<RecyclerVideoRequestModel, RecyclerVideoResponseModel>(request, cancellationToken);
        }

        [HttpGet("recycler/process​")]
        public async Task<IActionResult> getProcess(CancellationToken cancellationToken)
        {
            return await SendAsync<RecyclerVideoRequestModel, RecyclerVideoResponseModel>(new(), cancellationToken);
        }
    }
}
