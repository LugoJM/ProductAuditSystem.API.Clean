
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.File.Commands.Addfile;

public class CommandAddFiles : IRequest<BaseCommandResponse>
{
    public int QuestionId { get; set; }
    public bool IsReference { get; set; }
    public bool IsReferenceDocument { get; set; } 
    public IFormFileCollection? Files { get; set; }
}
