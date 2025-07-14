namespace FP.Domain.DTOs;

public class UpdateRoleDTO : CreateRoleDTO
{
    public required Guid Id { get; set; }
}
