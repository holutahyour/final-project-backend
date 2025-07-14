namespace FP.Domain.DTOs;

public class UpdateExpertiseDTO : CreateExpertiseDTO
{
    public required Guid Id { get; set; }
}
