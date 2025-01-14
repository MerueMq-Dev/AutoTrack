using System.ComponentModel.DataAnnotations;

namespace AutoTrack.Domain.Entities;

public class BaseEntity
{
    [Key] 
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? DeletedAt { get; set; }
}