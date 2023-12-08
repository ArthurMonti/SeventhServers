using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeventhServers.Domain;
using System.Net;

namespace SeventhServers.Controllers;


[ApiController]
public class BaseController : Controller
{
    private readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken) 
        where TRequest : IRequest<Result<TResponse>>
    {
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            if (!response.IsSuccess)
                return StatusCode(response.StatusCode, response.ErrorCode);

            return StatusCode(response.StatusCode, response.Data);
        }
        catch (Exception e)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
        }
    }
}
