
using AutoMapper;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.Question.Commands.CreateQuestion;
using ProductAuditSystem.Application.Features.Question.Commands.UpdateQuestion;

#nullable disable

namespace ProductAuditSystem.Application.MappingProfiles;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<Domain.Question, QuestionDTO>()
            .ForMember(dest => dest.SupportDepartment, opt => opt.MapFrom(src => new SupportDepartmentDTO
            {
                Id = src.Soporte.Id,
                Department = src.Soporte.Department
            }))
            .ForMember(dest => dest.EvaluationPoints, opt => opt.MapFrom(src => new EvaluationPointsDTO
            {
                Comments = src.ComentariosPuntos,
                Points = src.PuntosAEvaluar.Select(point => new EvaluationPointDTO
                {
                    idPunto = point.Id,
                    Contenido = point.Contenido,
                    PointStatus = new PointStatusDTO
                    {
                        Id = point.StatusPunto.Id,
                        Status = point.StatusPunto.Status
                    }
                }).ToList()
            }));
        CreateMap<CommandCreateQuestion, Domain.Question>()
            .ForMember(dest => dest.SoporteID, opt => opt.MapFrom(src => src.SupportDepartment.Id))
            .ForMember(dest => dest.ComentariosPuntos, opt => opt.MapFrom(src => src.EvaluationPoints.Comments));
        CreateMap<CommandUpdateQuestion, Domain.Question>()
            .ForMember(dest => dest.SoporteID, opt => opt.MapFrom(src => src.SupportDepartment.Id))
            .ForMember(dest => dest.ComentariosPuntos, opt => opt.MapFrom(src => src.EvaluationPoints.Comments));
        CreateMap<QuestionDTO, Domain.Question>()
            .ForMember(dest => dest.SoporteID, opt => opt.MapFrom(src => src.SupportDepartment.Id))
            .ForMember(dest => dest.ComentariosPuntos, opt => opt.MapFrom(src => src.EvaluationPoints.Comments));
    }
}
