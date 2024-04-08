using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.PointStatus.Commands.UpdatePointStatus;

internal class CommandUpdatePointStatusValidator : AbstractValidator<CommandUpdatePointStatus>
{
    private readonly IPointStatusRepository _pointStatusRepository;
    public CommandUpdatePointStatusValidator(IPointStatusRepository pointStatusRepository)
    {
        _pointStatusRepository = pointStatusRepository;

        RuleFor(p => p.Id)
            .MustAsync(PointStatusMustExist).WithMessage("El Point Status con ID '{PropertyValue}' no existe.");
    }

    private async Task<bool> PointStatusMustExist(int pointStatusID, CancellationToken token)
    {
        var pointStatus = await _pointStatusRepository.GetByIdAsync(pointStatusID);
        return pointStatus is not null;
    }
}
