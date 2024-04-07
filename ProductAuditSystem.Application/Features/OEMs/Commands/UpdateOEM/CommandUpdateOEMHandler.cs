
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.OEMs.Commands.UpdateOEM;

internal sealed class CommandUpdateOEMHandler : IRequestHandler<CommandUpdateOEM, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IOEMsRepository _OEMsRepository;

    public CommandUpdateOEMHandler(IMapper mapper, IOEMsRepository OEMsRepository)
    {
        _mapper = mapper;
        _OEMsRepository = OEMsRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandUpdateOEM request, CancellationToken cancellationToken)
    {
        var OEM = await _OEMsRepository.GetByIdAsync(request.Id);

        if (OEM is null)
            throw new NotFoundException(nameof(OEM), request.Id);

        _mapper.Map(request, OEM);

        await _OEMsRepository.UpdateAsync(OEM);
        return new BaseCommandResponse
        {
            Message = $"Se ha editado correctamente el OEM con ID:{request.Id}",
            Success = true
        };
    }
}
