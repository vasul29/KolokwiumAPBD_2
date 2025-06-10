namespace KolokwiumAPBD_2.Models.DTOs;

public class GetTrackRaceDataDTO
{
    public string RaceName { get; set; }
    public string TrackName { get; set; }
    public List<ParticipationInputDTO> Participations { get; set; }
}

public class ParticipationInputDTO
{
    public int RacerId { get; set; }
    public int Position { get; set; }
    public int FinishTimeInSeconds { get; set; }
}