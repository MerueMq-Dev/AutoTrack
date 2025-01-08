using System.ComponentModel.DataAnnotations;

namespace AutoTrack.Domain.Entities;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }
}