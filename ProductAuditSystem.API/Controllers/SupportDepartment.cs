using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductAuditSystem.Application.Features.SupportDepartment.Queries;
using ProductAuditSystem.Application.Features.SupportDepartment.Commands.CreateSupportDepartment;
using ProductAuditSystem.Application.Features.SupportDepartment.Commands.DeleteSupportDepartment;
using ProductAuditSystem.Application.Features.SupportDepartment.Commands.UpdateSupportDeparment;
using ProductAuditSystem.Application.Features.SupportDepartment.Queries.GetSupportDeparment;
using ProductAuditSystem.Application.Features.SupportDepartment.Queries.GetSupportDeparments;
using ProductAuditSystem.API.Controllers.Common;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupportDepartment : BaseController
{
    public SupportDepartment(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GetSupportDeparmentDTO>>> Get()
    {
        var supportDepartments = await _mediator.Send(new GetSupportDeparmentsQuery());
        return Ok(supportDepartments);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetSupportDeparmentDTO>> Get(int id)
    {
        var supportDepartment = await _mediator.Send(new GetSupportDeparmentQuery(id));
        return Ok(supportDepartment);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseCommandResponse>> Put(CommandUpdateSupportDepartment commandUpdate)
    {
        var response = await _mediator.Send(commandUpdate);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseCommandResponse>> Post(CommandCreateSupportDepartment createSupportDepartment)
    {
        var response = await _mediator.Send(createSupportDepartment);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
    {
        var response = await _mediator.Send(new CommandDeleteSupportDepartment(id));
        return Ok(response);
    }
}
