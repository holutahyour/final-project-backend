namespace FP.Domain.DTOs;

public class CreateDepartmentDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required Guid FacultyId { get; set; }
    public string Description { get; set; } = string.Empty;
}
