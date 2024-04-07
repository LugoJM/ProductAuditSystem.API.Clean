using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAuditSystem.API.Controllers.Common;
using ProductAuditSystem.Application.Features.File.Commands.Addfile;
using ProductAuditSystem.Application.Features.File.Commands.DeleteFile;
using ProductAuditSystem.Application.Features.File.Queries.GetFile;
using ProductAuditSystem.Application.Features.File.Queries.GetFiles;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN,AUDITOR")]
public class Files : BaseController
{
    public Files(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("questionFiles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Files>>> GetFiles(int questionID)
    {
        var files = await _mediator.Send(new GetFilesQuery(questionID));
        return Ok(files);
    }

    [HttpGet("{fileID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Files>> Get(int fileID)
    {
        var file = await _mediator.Send(new GetFileQuery(fileID));
        return Ok(file);
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CommandAddFiles commandAddFiles)
    {
        var response = await _mediator.Send(commandAddFiles);
        return Ok(response);
    }

    [HttpDelete("{fileID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseCommandResponse>> Delete(int fileID)
    {
        var response = await _mediator.Send(new CommandDeleteFile(fileID));
        return Ok(response);
    }
}
