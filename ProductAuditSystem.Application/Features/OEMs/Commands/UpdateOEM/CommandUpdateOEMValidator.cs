using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.OEMs.Commands.UpdateOEM;

internal class CommandUpdateOEMValidator : AbstractValidator<CommandUpdateOEM>
{
    private readonly IOEMsRepository _oEMsRepository;
    public CommandUpdateOEMValidator(IOEMsRepository oEMsRepository)
    {
        _oEMsRepository = oEMsRepository;

        RuleFor(p => p.Id)
            .MustAsync(OEMMustExist).WithMessage("El OEM con ID '{PropertyValue}' no existe.");

        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.");
    }

    private async Task<bool> OEMMustExist(int oemID, CancellationToken token)
    {
        var oem = await _oEMsRepository.GetByIdAsync(oemID);
        return oem is not null;
    }
}
