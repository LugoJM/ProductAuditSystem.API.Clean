
using AutoMapper;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.OEMs.Commands.CreateOEM;
using ProductAuditSystem.Application.Features.OEMs.Commands.UpdateOEM;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.MappingProfiles;

public class OEMsProfile : Profile
{
    public OEMsProfile()
    {
        CreateMap<OEM_DTO, OEM>().ReverseMap();
        CreateMap<CommandCreateOEM, OEM>();
        CreateMap<CommandUpdateOEM, OEM>();
    }
}
