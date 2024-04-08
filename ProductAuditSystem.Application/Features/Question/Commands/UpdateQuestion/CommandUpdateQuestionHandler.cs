
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Question.Commands.UpdateQuestion;

#nullable disable

internal sealed class CommandUpdateQuestionHandler : IRequestHandler<CommandUpdateQuestion, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _questionRepository;
    private readonly IEvaluationPointRepository _evaluationPointRepository;
    private readonly ISupportDepartmentRepository _supportDepartmentRepository;
    private readonly IAuditRepository _auditRepository;

    public CommandUpdateQuestionHandler(IMapper mapper, IQuestionRepository questionRepository, IEvaluationPointRepository evaluationPointRepository, ISupportDepartmentRepository supportDepartmentRepository, IAuditRepository auditRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
        _evaluationPointRepository = evaluationPointRepository;
        _supportDepartmentRepository = supportDepartmentRepository;
        _auditRepository = auditRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandUpdateQuestion request, CancellationToken cancellationToken)
    {
        var validator = new CommandUpdateQuestionValidator(_questionRepository, _supportDepartmentRepository,
            _auditRepository);

        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.Errors.Any())
            throw new BadRequestException("Comando Actualizar Pregunta Invalido.", validationResults);

        var questionToUpdate = await _questionRepository.GetByIdAsync(request.Id);

        _mapper.Map(request, questionToUpdate);

        await _questionRepository.UpdateAsync(questionToUpdate);

        request.EvaluationPoints.Points.ForEach(x => x.PreguntaId = request.Id);
        request.EvaluationPoints.Points.ForEach(x => x.StatusPuntoID = x.PointStatus.Id);

        var updatedEvaluationPoints = _mapper.Map<List<Domain.EvaluationPoint>>(request.EvaluationPoints.Points);

        await _evaluationPointRepository.UpdateEvaluationPoints(_mapper.Map<List<Domain.EvaluationPoint>>(request.EvaluationPoints.Points));

        return new BaseCommandResponse
        {
            Id = request.Id,
            Message = $"Se ha actualizado correctamente la pregunta con ID:{request.Id}",
            Success = true
        };

        

        //var questionToUpdate = await _pointStatusRepository.GetByIdAsync(request.Id);

        //_mapper.Map(request, questionToUpdate);

        //await _pointStatusRepository.UpdateAsync(questionToUpdate);

        ////var questionToUpdate = _mapper.Map<Domain.Question>(request);

        ////await _questionRepository.UpdateAsync(questionToUpdate);

        //request.EvaluationPoints.Points.ForEach(x => x.PreguntaId = request.Id);
        //request.EvaluationPoints.Points.ForEach(x => x.StatusPuntoID = x.PointStatus.Id);

        //var updatedEvaluationPoints = _mapper.Map<List<Domain.EvaluationPoint>>(request.EvaluationPoints.Points);

        //await _evaluationPointRepository.UpdateEvaluationPoints(_mapper.Map<List<Domain.EvaluationPoint>>(request.EvaluationPoints.Points));

        //return new BaseCommandResponse
        //{
        //    Id = request.Id,
        //    Message = $"Se ha actualizado correctamente la pregunta con ID:{request.Id}",
        //    Success = true
        //};
    }
}
