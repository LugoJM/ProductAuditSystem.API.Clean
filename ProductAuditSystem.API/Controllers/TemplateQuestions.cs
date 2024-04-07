using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAuditSystem.Application.Contracts.Infrastructure.JSONFileService;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN")]

public class TemplateQuestionsController : ControllerBase
{
    private readonly IJsonFileService _jsonFileService;

    public TemplateQuestionsController(IJsonFileService jsonFileService)
    {
        _jsonFileService = jsonFileService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> Get()
    {
        var templateQuestions = _jsonFileService.GetJsonFile();
        return Ok(templateQuestions);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] Object modifiedJson)
    {
        try
        {
            await _jsonFileService.SaveJsonFile(modifiedJson);
            var response = new BaseCommandResponse { Message = "Template Actualizado Correctamente!", Success = true };
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
