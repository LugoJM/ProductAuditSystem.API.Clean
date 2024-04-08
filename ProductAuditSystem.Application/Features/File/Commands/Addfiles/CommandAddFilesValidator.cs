using FluentValidation;
using Microsoft.AspNetCore.Http;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Features.File.Commands.Addfile;

namespace ProductAuditSystem.Application.Features.File.Commands.Addfiles;

internal class CommandAddFilesValidator : AbstractValidator<CommandAddFiles>
{
    private readonly IQuestionRepository _questionRepository;
    public CommandAddFilesValidator(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;

        RuleFor(p => p.QuestionId)
            .MustAsync(QuestionMustExist).WithMessage("La pregunta con ID '{PropertyValue}' no existe.");

        RuleFor(p => p.Files)
            .Must(FilesMustExist).WithMessage("El campo {PropertyName}' debe contener al menos 1 archivo.");
    }

    private bool FilesMustExist(IFormFileCollection files) => files.Count > 0;

    private async Task<bool> QuestionMustExist(int questionID, CancellationToken token)
    {
        var question = await _questionRepository.GetByIdAsync(questionID);
        return question is not null;
    }
}
