namespace FP.Domain.DTOs;

public class UpdateDepartmentDTO : CreateDepartmentDTO
{
    public required Guid Id { get; set; }
}
