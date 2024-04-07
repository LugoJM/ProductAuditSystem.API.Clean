
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Responses;
using ProductAuditSystem.Domain;

#nullable disable

namespace ProductAuditSystem.Application.Features.Question.Commands.CreateQuestion;

internal sealed class CommandCreateQuestionHandler : IRequestHandler<CommandCreateQuestion, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _questionRepository;
    private readonly IEvaluationPointRepository _evaluationPointRepository;
    private readonly IAuditQuestionRepository _auditQuestionRepository;

    public CommandCreateQuestionHandler(IMapper mapper, IQuestionRepository questionRepository, 
        IEvaluationPointRepository evaluationPointRepository, IAuditQuestionRepository auditQuestionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
        _evaluationPointRepository = evaluationPointRepository;
        _auditQuestionRepository = auditQuestionRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandCreateQuestion request, CancellationToken cancellationToken)
    {
        var question = _mapper.Map<Domain.Question>(request);
        await _questionRepository.CreateAsync(question);

        request.EvaluationPoints.Points.ForEach(x => x.PreguntaId = question.Id);
        request.EvaluationPoints.Points.ForEach(x => x.StatusPuntoID = x.PointStatus.Id);

        await _evaluationPointRepository.AddQuestionEvaluationPoints(_mapper.Map<List<EvaluationPoint>>(request.EvaluationPoints.Points));

        await _auditQuestionRepository.CreateAsync(
        new AuditQuestion
                    {
                        PreguntaID = question.Id,
                        AuditoriaID = request.AuditId
                    });


        return new BaseCommandResponse
        {
            Id = question.Id,
            Message = $"Se ha creado exitosamente la pregunta con el ID:{question.Id}",
            Success = true
        };
    }
}
