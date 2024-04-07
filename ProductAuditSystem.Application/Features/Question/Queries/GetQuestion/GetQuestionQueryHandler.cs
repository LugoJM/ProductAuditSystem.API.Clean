
using AutoMapper;
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Application.Exceptions;

namespace ProductAuditSystem.Application.Features.Question.Queries.GetQuestion;

#nullable disable

internal sealed class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, QuestionDTO>
{
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionQueryHandler(IMapper mapper, IQuestionRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }
    public async Task<QuestionDTO> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetQuestionById(request.Id);

        if (question == null)
            throw new NotFoundException(nameof(question), request.Id);

        var data = _mapper.Map<QuestionDTO>(question);

        var referenceFiles = _mapper.Map<List<FilesDTO>>(question.Files?.Where(f => f.IsReference).ToList());
        var evidenceFiles = _mapper.Map<List<FilesDTO>>(question.Files?.Where(f => !f.IsReference).ToList());
        var referenceDocumentFiles = _mapper.Map<List<FilesDTO>>(question.Files.Where(f => f.IsReference).ToList());

        data.ReferenceFiles = referenceFiles;
        data.EvidenceFiles = evidenceFiles;
        data.ReferenceDocumentFiles = referenceDocumentFiles;

        return data;
    }
}
