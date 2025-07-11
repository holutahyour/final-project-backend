using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FP.Backend.Base.Domain.Entities;

public class AuditableEntity
{
    [BsonRepresentation(BsonType.String)]
    public DateTime CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    [BsonRepresentation(BsonType.String)]
    public DateTime LastModifiedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsActive { get; set; } = true;

    public bool? IsDeleted { get; set; } = false;
}
