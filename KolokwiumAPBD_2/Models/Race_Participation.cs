using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumAPBD_2.Models;

[Table("Race_Participation")]
[PrimaryKey(nameof(TrackRaceId), nameof(RacerId))]
public class Race_Participation
{
    public int TrackRaceId { get; set; }
    
    public int RacerId { get; set; }

    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }

    [ForeignKey("TrackRaceId")] public Track_Race TrackRace { get; set; } = null!;

    [ForeignKey("RacerId")] public Racer Racer { get; set; } = null!;
}