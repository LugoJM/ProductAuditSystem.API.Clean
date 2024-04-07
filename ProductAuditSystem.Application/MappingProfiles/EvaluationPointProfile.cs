
using AutoMapper;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.Question.Classes;
using ProductAuditSystem.Domain;

#nullable disable

namespace ProductAuditSystem.Application.MappingProfiles;

public class EvaluationPointProfile : Profile
{
    public EvaluationPointProfile()
    {
        CreateMap<EvaluationPoint, EvaluationPointsDTO>()
            .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.StatusPunto));
        CreateMap<EvaluationPointDTO, EvaluationPoint>()
            .ForMember(dest => dest.StatusPuntoID, opt => opt.MapFrom(src => src.PointStatus.Id));
        CreateMap<QuestionEP, EvaluationPoint>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdPunto));
    }
}
