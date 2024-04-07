
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.OEMs.Commands.CreateOEM;

internal sealed class CommandCreateOEMHandler : IRequestHandler<CommandCreateOEM, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IOEMsRepository _OEMsRepository;

    public CommandCreateOEMHandler(IMapper mapper, IOEMsRepository OEMsRepository)
    {
        _mapper = mapper;
        _OEMsRepository = OEMsRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandCreateOEM request, CancellationToken cancellationToken)
    {
        var createOEM = _mapper.Map<OEM>(request);
        var OEMExists = _OEMsRepository.CheckOEM(createOEM);

        if (OEMExists.Result)
            throw new BadRequestException("Este OEM ya se encuentra registrado!");

        await _OEMsRepository.CreateAsync(createOEM);
        return new BaseCommandResponse
        {
            Id = createOEM.Id,
            Message = $"Se ha creado el OEM con ID:{createOEM.Id}",
            Success = true,
        };
    }
}
