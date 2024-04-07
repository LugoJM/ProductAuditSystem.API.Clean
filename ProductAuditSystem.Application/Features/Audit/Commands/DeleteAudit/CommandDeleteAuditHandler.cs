using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

#nullable disable

namespace ProductAuditSystem.Application.Features.Audit.Commands.DeleteAudit;

internal sealed class CommandDeleteAuditHandler : IRequestHandler<CommandDeleteAudit, BaseCommandResponse>
{
    private readonly IAuditRepository _auditRepository;
    private readonly IQuestionRepository _questionRepository;

    public CommandDeleteAuditHandler(IAuditRepository auditRepository, IQuestionRepository questionRepository)
    {
        _auditRepository = auditRepository;
        _questionRepository = questionRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandDeleteAudit request, CancellationToken cancellationToken)
    {
        var auditToDelete = await _auditRepository.GetByIdAsync(request.AuditID);

        if (auditToDelete == null)
            throw new NotFoundException(nameof(auditToDelete), request.AuditID);

        var questions = await _questionRepository.GetAuditQuestions(request.AuditID);

        await _questionRepository.DeleteAuditQuestions(questions);

        await _auditRepository.DeleteAsync(auditToDelete);

        return new BaseCommandResponse
        {
            Id = request.AuditID,
            Message = $"Se ha eliminado exitosamente la auditoria con ID:{request.AuditID}",
            Success = true
        };
    }
}
