namespace KolokwiumAPBD_2.Models.DTOs;

public class RacerGetDTO
{
    public int RacerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<RaceParticipationDTO> Participations { get; set; }
}

public class RaceParticipationDTO
{
    public RaceInfoDTO Race { get; set; }
    public TrackInfoDTO Track { get; set; }
    public int Laps { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}

public class RaceInfoDTO
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
}

public class TrackInfoDTO
{
    public string Name { get; set; }
    public decimal LengthInKm { get; set; }
}
