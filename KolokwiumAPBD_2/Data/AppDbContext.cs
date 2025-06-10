using KolokwiumAPBD_2.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumAPBD_2.Data;

public class AppDbContext : DbContext
{
    public DbSet<Race> Races { get; set; }
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Race_Participation> RaceParticipations { get; set; }
    public DbSet<Track_Race> TrackRaces { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Race_Participation>()
            .HasOne(rp => rp.TrackRace)
            .WithMany(tr => tr.RaceParticipations)
            .HasForeignKey(rp => rp.TrackRaceId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Race_Participation>()
            .HasOne(rp => rp.Racer)
            .WithMany(r => r.RaceParticipations)
            .HasForeignKey(rp => rp.RacerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}