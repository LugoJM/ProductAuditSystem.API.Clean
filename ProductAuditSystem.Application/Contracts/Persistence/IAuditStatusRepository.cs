﻿
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Contracts.Persistence;

public interface IAuditStatusRepository : IGenericRepository<AuditStatus>
{
    Task<AuditStatus?> FindStatus(string status);
}
