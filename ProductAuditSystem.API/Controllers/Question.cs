using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductAuditSystem.API.Controllers.Common;
using ProductAuditSystem.Application.Features.Question.Queries.GetQuestions;
using ProductAuditSystem.Application.Features.Question.Queries.GetQuestion;
using ProductAuditSystem.Application.Features.Question.Commands.CreateQuestion;
using ProductAuditSystem.Application.Features.Question.Commands.UpdateQuestion;
using ProductAuditSystem.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN,AUDITOR")]

public class Question : BaseController
{
    public Question(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<QuestionDTO>>> Get()
    {
        var questions = await _mediator.Send(new GetQuestionsQuery());
        return Ok(questions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QuestionDTO>> Get(int id)
    {
        var question = await _mediator.Send(new GetQuestionQuery(id));
        return Ok(question);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseCommandResponse>> Post(CommandCreateQuestion commandCreateQuestion)
    {
        var response = await _mediator.Send(commandCreateQuestion);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseCommandResponse>> Put(CommandUpdateQuestion commandUpdateQuestion)
    {
        var response = await _mediator.Send(commandUpdateQuestion);
        return Ok(response);
    }
}