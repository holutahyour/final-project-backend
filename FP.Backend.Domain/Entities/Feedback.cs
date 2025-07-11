namespace FP.Backend.Domain.Entities;

public class Feedback : BaseEntity<Guid>
{
    public Guid SubmissionId { get; set; }

    public Guid ReviewerId { get; set; }

    public Guid RevisionId { get; set; }

    public string Content { get; set; }

    public int Page { get; set; }
}

