﻿
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Responses;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandCreateAuditStatus;

internal sealed class CommandCreateAuditStatusHandler : IRequestHandler<CommandCreateAuditStatus, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAuditStatusRepository _auditStatusRepository;

    public CommandCreateAuditStatusHandler(IMapper mapper, IAuditStatusRepository auditStatusRepository)
    {
        _mapper = mapper;
        _auditStatusRepository = auditStatusRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandCreateAuditStatus request, CancellationToken cancellationToken)
    {
        var auditStatusToCreate = _mapper.Map<Domain.AuditStatus>(request);
        await _auditStatusRepository.CreateAsync(auditStatusToCreate);
        return new BaseCommandResponse
        {
            Id = auditStatusToCreate.Id,
            Message = $"Se ha creado exitosamente el Audit Status con ID:{auditStatusToCreate.Id}",
            Success = true
        };
    }
}