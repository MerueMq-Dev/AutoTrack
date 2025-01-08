using AutoTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AutoTrack.Domain;

public class AutoTrackDbContext : DbContext
{
    public DbSet<VehicleEntity> Vehicles { get; set; }
    
    public AutoTrackDbContext(DbContextOptions<AutoTrackDbContext> options):base(options)
    {
    }
    
    public AutoTrackDbContext()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    
}