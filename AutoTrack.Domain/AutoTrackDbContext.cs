using AutoTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AutoTrack.Domain;

public class AutoTrackDbContext : DbContext
{
    public AutoTrackDbContext(DbContextOptions<AutoTrackDbContext> options):base(options)
    {
    }
    
    public AutoTrackDbContext()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    public DbSet<VehicleEntity> Vehicles { get; set; }
    public DbSet<CarModelEntity> CarModels { get; set; }
}