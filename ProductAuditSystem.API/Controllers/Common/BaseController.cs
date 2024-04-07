using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductAuditSystem.API.Controllers.Common;

[ApiController]
public class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
