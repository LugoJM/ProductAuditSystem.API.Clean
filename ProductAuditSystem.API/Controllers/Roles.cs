using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using ProductAuditSystem.Application.Features.Roles.Commands.CommandDeleteRol;
using ProductAuditSystem.Application.Features.Roles.Commands.CommandCreateRol;
using ProductAuditSystem.Application.Features.Roles.Queries;
using ProductAuditSystem.Application.Features.Roles.Queries.GetRoles;
using ProductAuditSystem.Application.Features.Roles.Queries.GetRol;
using ProductAuditSystem.API.Controllers.Common;
using ProductAuditSystem.Application.Responses;
using ProductAuditSystem.Application.Features.Roles.Commands.CommandUpdateRol;

namespace ProductAuditSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN")]
public class Roles : BaseController
{
    public Roles(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GetRolDTO>>> Get()
    {
        var roles = await _mediator.Send(new GetRolesQuery());
        return Ok(roles);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetRolDTO>> Get(int id)
    {
        var rol = await _mediator.Send(new GetRolQuery(id));
        return Ok(rol);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseCommandResponse>> Post(CommandCreateRol comandoCrearRol)
    {
        var response = await _mediator.Send(comandoCrearRol);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseCommandResponse>> Put(CommandUpdateRol comandoBorrarRol)
    {
        var response = await _mediator.Send(comandoBorrarRol);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
    {
        var response = await _mediator.Send(new CommandDeleteRol(id));
        return Ok(response);
    }
}
