
using Microsoft.EntityFrameworkCore;
using ProductAuditSystem.Application.Contracts.Persistence;
using ProductAuditSystem.Domain;
using ProductAuditSystem.Persistence.DataBaseContext;

namespace ProductAuditSystem.Persistence.Repositories;

#nullable disable

public class FilesRepository : GenericRepository<Files>, IFilesRepository
{
    public FilesRepository(ProductAuditSystemDBContext context) : base(context)
    {
    }

    public async Task AddFiles(List<Files> files)
    {
        _context.AddRange(files);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFile(Files file)
    {
        _context.Files.Remove(file);
        await _context.SaveChangesAsync();
    }

    public Task<Files> GetFile(int id)
    {
        var file = _context.Files.FirstOrDefaultAsync(f => f.Id == id);
        return file;
    }

    public async Task<List<Files>> GetFiles(int questionID)
    {
        var files = await _context.Files.Where(f => f.QuestionID == questionID)
            .ToListAsync();
        return files;
    }
        
}
