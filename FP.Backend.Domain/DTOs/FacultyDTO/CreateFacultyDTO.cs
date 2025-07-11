namespace FP.Domain.DTOs;

public class CreateFacultyDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
}
