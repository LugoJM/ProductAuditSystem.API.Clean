
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.SupportDepartment.Commands.CreateSupportDepartment;
using ProductAuditSystem.Application.Features.SupportDepartment.Commands.UpdateSupportDeparment;
using ProductAuditSystem.Application.Features.SupportDepartment.Queries;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.MappingProfiles;

public class SupportDepartmentProfile : Profile
{
    public SupportDepartmentProfile()
    {
        CreateMap<GetSupportDeparmentDTO, SupportDepartment>().ReverseMap();
        CreateMap<SupportDepartmentDTO, SupportDepartment>().ReverseMap();
        CreateMap<SupportDepartment, Unit>();
        CreateMap<CommandCreateSupportDepartment, SupportDepartment>();
        CreateMap<CommandUpdateSupportDepartment, SupportDepartment>();
    }
}
