namespace FP.Domain.DTOs;

public class CreateRoleDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Value { get; set; }
    public string Description { get; set; } = string.Empty;
}
