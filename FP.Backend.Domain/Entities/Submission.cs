namespace FP.Backend.Domain.Entities;

public class Submission : BaseEntity<Guid>
{

    public Guid UserId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Abstract { get; set; } = string.Empty;

    public string Keyword { get; set; } = string.Empty;

    public string FileUrl { get; set; } = string.Empty;

    public int Status { get; set; } = 1;

    public int ApprovalStatus { get; set; } = 1;

    public List<Guid> ReviewerIds { get; set; } = [];

}