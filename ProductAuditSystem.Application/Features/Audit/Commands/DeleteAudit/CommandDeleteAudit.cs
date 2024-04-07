using MediatR;
using ProductAuditSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAuditSystem.Application.Features.Audit.Commands.DeleteAudit;

public record CommandDeleteAudit(int AuditID) : IRequest<BaseCommandResponse>;
