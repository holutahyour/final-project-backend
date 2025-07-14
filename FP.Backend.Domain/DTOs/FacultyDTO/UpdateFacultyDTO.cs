namespace FP.Domain.DTOs;

public class UpdateFacultyDTO : CreateFacultyDTO
{
    public required Guid Id { get; set; }
}
