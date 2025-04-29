using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController(IMediator Mediator) : ControllerBase
    {
    }
}
