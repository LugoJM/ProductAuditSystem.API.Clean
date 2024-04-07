
using ProductAuditSystem.Domain.Common;

namespace ProductAuditSystem.Domain;

public class Files : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public byte[]? Content { get; set; }
    public string MIME_Type { get; set; } = string.Empty;
    public int QuestionID { get; set; }
    public virtual Question? Question { get; set; }
    public bool IsReference { get; set; }
    public bool IsReferenceDocument { get; set; }
}
