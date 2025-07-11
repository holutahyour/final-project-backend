namespace FP.Backend.Domain.Entities;

public class Revision : BaseEntity<Guid>
{
    public Guid UserId { get; set; }

    public Guid SubmissionId { get; set; }

    public string Version { get; set; } = string.Empty;

    public string FileUrl { get; set; } = string.Empty;

    public int Status { get; set; } = 1;

    public List<Guid> FeedbackIds { get; set; } = [];
}

