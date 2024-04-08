using FluentValidation;
using ProductAuditSystem.Application.Contracts.Persistence;

namespace ProductAuditSystem.Application.Features.OEMs.Commands.CreateOEM;

internal class CommandCreateOEMValidator : AbstractValidator<CommandCreateOEM>
{
    private readonly IOEMsRepository _oEMsRepository;
    public CommandCreateOEMValidator(IOEMsRepository oEMsRepository)
    {
        _oEMsRepository = oEMsRepository;

        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El campo '{PropertyName}' no puede estar vacio.")
            .MustAsync(OEMMustNotExist).WithMessage("El OEM '{PropertyValue} ya existe.");
    }

    private async Task<bool> OEMMustNotExist(string oemName, CancellationToken token)
    {
        var oem = await _oEMsRepository.FindOEM(oemName);
        return oem is null;
    }
}
