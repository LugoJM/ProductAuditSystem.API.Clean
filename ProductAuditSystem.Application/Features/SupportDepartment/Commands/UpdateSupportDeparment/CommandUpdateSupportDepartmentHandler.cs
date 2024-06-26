﻿
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.SupportDepartment.Commands.UpdateSupportDeparment;

internal sealed class CommandUpdateSupportDepartmentHandler : IRequestHandler<CommandUpdateSupportDepartment, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ISupportDepartmentRepository _supportDepartmentRepository;

    public CommandUpdateSupportDepartmentHandler(IMapper mapper, ISupportDepartmentRepository supportDepartmentRepository)
    {
        _mapper = mapper;
        _supportDepartmentRepository = supportDepartmentRepository;
    }
    public async Task<BaseCommandResponse> Handle(CommandUpdateSupportDepartment request, CancellationToken cancellationToken)
    {
        var validator = new CommandUpdateSupportDepartmentValidator(_supportDepartmentRepository);
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.Errors.Any())
            throw new BadRequestException("Comando Actualizar Departamento de Soporte Invalido", validationResults);

        var updateSupportDepartment = await _supportDepartmentRepository.GetByIdAsync(request.Id);

        _mapper.Map(request, updateSupportDepartment);

        await _supportDepartmentRepository.UpdateAsync(updateSupportDepartment);

        return new BaseCommandResponse
        {
            Id = request.Id,
            Message = $"Se ha actualizado el Departamento con ID:{request.Id}",
            Success = true
        };
    }
}
