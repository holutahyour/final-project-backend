namespace FP.Backend.Domain.Entities;

public class Department : BaseEntity<Guid>
{
    public required Guid FacultyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}