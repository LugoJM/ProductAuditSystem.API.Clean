using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAuditSystem.API.Controllers.Common;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.OEMs.Commands.CreateOEM;
using ProductAuditSystem.Application.Features.OEMs.Commands.DeleteOEM;
using ProductAuditSystem.Application.Features.OEMs.Commands.UpdateOEM;
using ProductAuditSystem.Application.Features.OEMs.Queries.GetOEM;
using ProductAuditSystem.Application.Features.OEMs.Queries.GetOEMs;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN")]
public class OEMs : BaseController
{
    public OEMs(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<OEM_DTO>> Get()
    {
        var OEMs = await _mediator.Send(new GetOEMsQuery());
        return Ok(OEMs);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OEM_DTO>> Get(int id)
    {
        var OEM = await _mediator.Send(new GetOEMQuery(id));
        return Ok(OEM);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseCommandResponse>> Post(CommandCreateOEM createOEM)
    {
        var response = await _mediator.Send(createOEM);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseCommandResponse>> Put(CommandUpdateOEM updateOEM)
    {
        var response = await _mediator.Send(updateOEM);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
    {
        var response = await _mediator.Send(new CommandDeleteOEM(id));
        return Ok(response);
    }
}
