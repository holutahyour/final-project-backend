namespace FP.Backend.Domain.Entities;

public class Faculty : BaseEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}