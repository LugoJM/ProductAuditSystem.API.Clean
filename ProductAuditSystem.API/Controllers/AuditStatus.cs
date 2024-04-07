using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAuditSystem.API.Controllers.Common;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandCreateAuditStatus;
using ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandDeleteAuditStatus;
using ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandUpdateAuditStatus;
using ProductAuditSystem.Application.Features.AuditStatus.Queries.GetAuditsStatus;
using ProductAuditSystem.Application.Features.AuditStatus.Queries.GetAuditStatus;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN")]
public class AuditStatus : BaseController
{
    public AuditStatus(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ActionResult<List<AuditStatusDTO>>>> Get()
    {
        var roles = await _mediator.Send(new GetAuditsStatusQuery());
        return Ok(roles);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<AuditStatusDTO>> Get(int id)
    {
        var rol = await _mediator.Send(new GetAuditStatusQuery(id));
        return Ok(rol);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseCommandResponse>> Post(CommandCreateAuditStatus commandCreateAuditStatus)
    {
        var response = await _mediator.Send(commandCreateAuditStatus);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseCommandResponse>> Put(CommandUpdateAuditStatus commandUpdateAuditStatus)
    {
        var response = await _mediator.Send(commandUpdateAuditStatus);
        return Ok(response);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseCommandResponse>> Delete(CommandDeleteAuditStatus commandDeleteAuditStatus)
    {
        var response = await _mediator.Send(commandDeleteAuditStatus);
        return Ok(response);
    }
}
