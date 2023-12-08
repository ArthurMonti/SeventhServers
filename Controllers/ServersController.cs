using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeventhServers.Domain.UseCases.Servers.Create;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

       
    }
}
