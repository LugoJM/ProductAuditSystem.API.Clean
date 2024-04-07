
using AutoMapper;
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.MappingProfiles;

public class FilesProfile : Profile
{
    public FilesProfile()
    {
        CreateMap<Domain.Files, FilesDTO>();
    }
}
