using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;

namespace ProductAuditSystem.Application.Features.Audit.Queries.GetAudit;

#nullable disable
internal sealed class GetAuditQueryHandler : IRequestHandler<GetAuditQuery, GetAuditDTO>
{
    private readonly IMapper _mapper;
    private readonly IAuditRepository _auditRepository;
    private readonly IUserRepository _userRepository;

    public GetAuditQueryHandler(IMapper mapper, IAuditRepository auditRepository, IUserRepository userRepository)
    {
        _mapper = mapper;
        _auditRepository = auditRepository;
        _userRepository = userRepository;
    }
    public async Task<GetAuditDTO> Handle(GetAuditQuery request, CancellationToken cancellationToken)
    {
        var auditoria = await _auditRepository.GetAudit(request.ID);

        if (auditoria == null)
            throw new NotFoundException(nameof(auditoria), request.ID);
        
        var datos = _mapper.Map<GetAuditDTO>(auditoria);

        var auditores = auditoria.UsuariosAuditorias.Select(au => _mapper.Map<UserDTO>(_userRepository.GetUserById(au.UsuarioID).Result)).ToList();

        var questionDTOs = auditoria.AuditoriasPreguntas.Select(question =>
        {
            var questionDTO = _mapper.Map<QuestionDTO>(question.Pregunta);
            questionDTO.ReferenceFiles = _mapper.Map<List<FilesDTO>>(question.Pregunta.Files?.Where(f => f.IsReference).ToList());
            questionDTO.EvidenceFiles = _mapper.Map<List<FilesDTO>>(question.Pregunta.Files?.Where(f => !f.IsReference && !f.IsReferenceDocument).ToList());
            questionDTO.ReferenceDocumentFiles = _mapper.Map<List<FilesDTO>>(question.Pregunta.Files?.Where(f => f.IsReferenceDocument).ToList());
            return questionDTO;
        }).ToList();

        datos.Auditores = auditores;
        datos.Preguntas = questionDTOs;

        return datos;
    }
}
