
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandCreateAuditStatus;
using ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandUpdateAuditStatus;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.MappingProfiles;

public class AuditStatusProfile : Profile
{
    public AuditStatusProfile()
    {

        CreateMap<AuditStatusDTO, AuditStatus>().ReverseMap();
        CreateMap<AuditStatus, StatusDTO>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();
        CreateMap<PointStatus, Unit>();
        CreateMap<CommandCreateAuditStatus, AuditStatus>();
        CreateMap<CommandUpdateAuditStatus, AuditStatus>();
    }
}
