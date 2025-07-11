namespace FP.Backend.Domain.Entities;

public class Role : BaseEntity<Guid>
{
    public required string Name { get; set; }
    public required string Value { get; set; }
    public string Description { get; set; } = string.Empty;
}