using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumAPBD_2.Models;
[Table("Track_Race")]
public class Track_Race
{
    [Key]
    public int TrackRaceId { get; set; }

    [ForeignKey("Track")]
    public int TrackId { get; set; }

    [ForeignKey("Race")]
    public int RaceId { get; set; }

    [ForeignKey("Racer")]
    public int RacerId { get; set; }

    public int Laps { get; set; }
    public int? BestTimeInSeconds { get; set; }

    public Track Track { get; set; } = null!;
    public Race Race { get; set; } = null!;
    public Racer Racer { get; set; } = null!;
    public ICollection<Race_Participation> RaceParticipations { get; set; }
}