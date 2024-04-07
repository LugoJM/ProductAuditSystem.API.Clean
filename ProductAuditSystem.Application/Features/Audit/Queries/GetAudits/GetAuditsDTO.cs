﻿using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.Audit.Queries.GetAudits;

public class GetAuditsDTO
{
    public int Id { get; set; }
    public DateTime? Fecha_Auditoria { get; set; }
    public OEM_DTO? OEM { get; set; }
    public string Programa { get; set; } = string.Empty;
    public List<UserDTO>? Auditores { get; set; }
    public StatusDTO? Status { get; set; }
}
