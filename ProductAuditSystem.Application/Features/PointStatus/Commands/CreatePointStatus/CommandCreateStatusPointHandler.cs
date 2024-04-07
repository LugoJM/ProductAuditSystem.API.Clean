﻿
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.PointStatus.Commands.CreatePointStatus;

internal sealed class CommandCreateStatusPointHandler : IRequestHandler<CommandCreateStatusPoint, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IPointStatusRepository _pointStatusRepository;

    public CommandCreateStatusPointHandler(IMapper mapper, IPointStatusRepository pointStatusRepository)
    {
        _mapper = mapper;
        _pointStatusRepository = pointStatusRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandCreateStatusPoint request, CancellationToken cancellationToken)
    {
        var pointStatusToCreate = _mapper.Map<Domain.PointStatus>(request);
        await _pointStatusRepository.CreateAsync(pointStatusToCreate);
        return new BaseCommandResponse
        {
            Id = pointStatusToCreate.Id,
            Message = $"Se ha creado el Point Status con ID:{pointStatusToCreate.Id}",
            Success = true
        };
    }
}