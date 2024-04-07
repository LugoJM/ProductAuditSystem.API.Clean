
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.OEMs.Commands.DeleteOEM;

internal sealed class CommandDeleteOEMHandler : IRequestHandler<CommandDeleteOEM, BaseCommandResponse>
{
    private readonly IOEMsRepository _OEMsRepository;

    public CommandDeleteOEMHandler(IOEMsRepository OEMsRepository)
    {
        _OEMsRepository = OEMsRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandDeleteOEM request, CancellationToken cancellationToken)
    {
        var OEMtoDelete = await _OEMsRepository.GetByIdAsync(request.Id);

        if (OEMtoDelete == null)
            throw new NotFoundException(nameof(OEMtoDelete), request.Id);

        await _OEMsRepository.DeleteAsync(OEMtoDelete);

        return new BaseCommandResponse
        {
            Message = $"Se ha eliminado el OEM con ID:{request.Id}",
            Success = true
        };
    }
}
