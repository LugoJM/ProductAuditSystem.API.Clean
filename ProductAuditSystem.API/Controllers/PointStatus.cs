using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAuditSystem.API.Controllers.Common;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.PointStatus.Commands.CreatePointStatus;
using ProductAuditSystem.Application.Features.PointStatus.Commands.DeletePointStatus;
using ProductAuditSystem.Application.Features.PointStatus.Commands.UpdatePointStatus;
using ProductAuditSystem.Application.Features.PointStatus.Queries.GetPointsStatus;
using ProductAuditSystem.Application.Features.PointStatus.Queries.GetPointStatus;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN")]
public class PointStatus : BaseController
{
    public PointStatus(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PointStatusDTO>>> Get()
    {
        var roles = await _mediator.Send(new GetPointsStatusQuery());
        return Ok(roles);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PointStatusDTO>> Get(int id)
    {
        var rol = await _mediator.Send(new GetPointStatusQuery(id));
        return Ok(rol);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseCommandResponse>> Post(CommandCreateStatusPoint createStatusPoint)
    {
        var response = await _mediator.Send(createStatusPoint);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseCommandResponse>> Put(CommandUpdatePointStatus updatePointStatus)
    {
        var response = await _mediator.Send(updatePointStatus);
        return Ok(response);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
    {
        var response = await _mediator.Send(new CommandDeletePointStatus(id));
        return Ok(response);
    }
}
