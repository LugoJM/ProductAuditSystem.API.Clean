﻿
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.PointStatus.Commands.UpdatePointStatus;

internal sealed class CommandUpdatePointStatusHandler : IRequestHandler<CommandUpdatePointStatus, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IPointStatusRepository _pointStatusRepository;

    public CommandUpdatePointStatusHandler(IMapper mapper, IPointStatusRepository pointStatusRepository)
    {
        _mapper = mapper;
        _pointStatusRepository = pointStatusRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandUpdatePointStatus request, CancellationToken cancellationToken)
    {
        var validator = new CommandUpdatePointStatusValidator(_pointStatusRepository);
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.Errors.Any())
            throw new BadRequestException("Comando Actualizar Status Point Invalido", validationResults);

        var pointStatusToUpdate = await _pointStatusRepository.GetByIdAsync(request.Id);

        _mapper.Map(request, pointStatusToUpdate);

        await _pointStatusRepository.UpdateAsync(pointStatusToUpdate);

        return new BaseCommandResponse
        {
            Id = request.Id,
            Message = $"Se ha actualizado el Point Status con ID:{request.Id}",
            Success = true
        };
    }
}
