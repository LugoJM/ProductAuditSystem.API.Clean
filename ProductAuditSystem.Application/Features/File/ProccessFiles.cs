
using Microsoft.AspNetCore.Http;
using ProductAuditSystem.Domain;

namespace ProductAuditSystem.Application.Features.File;

internal sealed class ProccessFiles
{
    public async Task<Files?> GetFile(IFormFile file, int QuestionId, 
        bool reference = false, bool referenceDocument = false)
    {
        var proccessedFile = await ProcessFile(file, reference, referenceDocument, QuestionId);
        return proccessedFile;
    }

    public async Task<List<Files>> GetFiles(IFormFileCollection files, int QuestionId, 
        bool reference = false, bool referenceDocument = false)
    {
        var filesList = new List<Files>();
        foreach (var file in files)
        {
            var proccessedFile = await ProcessFile(file, reference, referenceDocument, QuestionId);
            if (proccessedFile != null)
            {
                filesList.Add(proccessedFile);
            }
        }
        return filesList;
    }

    private async Task<Files?> ProcessFile(IFormFile file, bool isReference, 
        bool isReferenceDocument, int questionId)
    {
        if (file != null && file.Length > 0)
        {
            var fileEntity = new Files
            {
                Name = file.FileName,
                Content = await ReadFileContent(file),
                MIME_Type = file.ContentType,
                IsReference = isReference,
                IsReferenceDocument = isReferenceDocument,
                QuestionID = questionId
            };
            return fileEntity;
        }
        return null;
    }

    private async Task<byte[]> ReadFileContent(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}
