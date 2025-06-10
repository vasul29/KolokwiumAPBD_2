using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumAPBD_2.Models;

[Table("Track")]
public class Track
{
    [Key]
    public int TrackId { get; set; }

    [MaxLength(100)] public string Name { get; set; } = null!;
    
    public decimal LengthInKm { get; set; }

    public ICollection<Track_Race> TrackRaces { get; set; } = null!;
}