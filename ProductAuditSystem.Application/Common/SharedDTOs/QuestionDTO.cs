namespace ProductAuditSystem.Application.Common.SharedDTOs;

public class QuestionDTO
{
    public int ID { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public EvaluationPointsDTO? EvaluationPoints { get; set; }
    public SupportDepartmentDTO? SupportDepartment { get; set; }
    public string Comentarios { get; set; } = string.Empty;
    public string referenceDocuments { get; set; } = string.Empty;
    public List<FilesDTO> ReferenceFiles { get; set; } = new();
    public List<FilesDTO> EvidenceFiles { get; set; } = new();
    public List<FilesDTO> ReferenceDocumentFiles { get; set; } = new();
}
