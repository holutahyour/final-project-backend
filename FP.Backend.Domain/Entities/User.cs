namespace FP.Backend.Domain.Entities;

public class User : BaseEntity<Guid>
{
    public required string UserName { get; set; } = string.Empty;

    public required string Email { get; set; } = string.Empty;

    public required string Title { get; set; } = string.Empty;

    public required string FirstName { get; set; } = string.Empty;

    public required string LastName { get; set; } = string.Empty;

    public required string Phone { get; set; } = string.Empty;

    public required List<Guid> Roles { get; set; } = [];

    public required Guid FacultyId { get; set; }

    public required Guid DepartmentId { get; set; }

    public Guid? ExpertiseId { get; set; }

    public string MatriculationNumber { get; set; } = string.Empty;

    public Guid? LevelId { get; set; }

}