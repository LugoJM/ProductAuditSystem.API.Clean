using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.PointStatus.Commands.CreatePointStatus;

internal class CommandCreateStatusPointValidator : AbstractValidator<CommandCreateStatusPoint>
{
    private readonly IPointStatusRepository _pointStatusRepository;
    public CommandCreateStatusPointValidator(IPointStatusRepository pointStatusRepository)
    {
        _pointStatusRepository = pointStatusRepository;

        RuleFor(p => p.Status)
            .NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacio.")
            .MustAsync(StatusMustNotExist).WithMessage("El status '{PropertyValue}' ya existe.");
    }

    private async Task<bool> StatusMustNotExist(string status, CancellationToken token)
    {
        var pointStatus = await _pointStatusRepository.FindPointStatus(status);
        return pointStatus is null;
    }
}
