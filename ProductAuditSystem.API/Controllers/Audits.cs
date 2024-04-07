using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductAuditSystem.Application.Features.Audit.Queries.GetAudit;
using ProductAuditSystem.Application.Features.Audit.Queries.GetAudits;
using ProductAuditSystem.Application.Features.Audit.Commands.CreateAudit;
using ProductAuditSystem.Application.Features.Audit.Commands.DeleteAudit;
using ProductAuditSystem.API.Controllers.Common;
using ProductAuditSystem.Application.Features.Audit.Commands.UpdateAudit;
using ProductAuditSystem.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ProductAuditSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN,AUDITOR")]

public class Audits : BaseController
{
    public Audits(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GetAuditsDTO>>> Get()
    {
        var auditorias = await _mediator.Send(new GetAuditsQuery());
        return Ok(auditorias);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetAuditDTO>> Get(int id)
    {
        var auditoria = await _mediator.Send(new GetAuditQuery(id));
        return Ok(auditoria);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseCommandResponse>> Post(CommandCreateAudit createAuditTypeCommand)
    {
        var response = await _mediator.Send(createAuditTypeCommand);
        return Ok(response);
    }   

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseCommandResponse>> Put(CommandUpdateAudit commandUpdateAudit)
    {
        var response = await _mediator.Send(commandUpdateAudit);
        return Ok(response);
    }

    [HttpDelete("{auditID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseCommandResponse>> Delete(int auditID)
    {
        var response = await _mediator.Send(new CommandDeleteAudit(auditID));
        return Ok(response);
    }
}
