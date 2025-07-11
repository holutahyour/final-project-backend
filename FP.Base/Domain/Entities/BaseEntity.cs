using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace FP.Backend.Base.Domain.Entities;

public class BaseEntity<T> : AuditableEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; }

    [BsonElement("code")]
    public string Code { get; set; }
}
