using KolokwiumAPBD_2.Data;
using KolokwiumAPBD_2.Exceptions;
using KolokwiumAPBD_2.Models;
using KolokwiumAPBD_2.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumAPBD_2.Services;

public interface IDbService
{
    public Task<RacerGetDTO> GetRacerDetailsAsync(int id);
    public Task GetNewTrackDataAsync(GetTrackRaceDataDTO data);
}
public class DbService(AppDbContext dbContext) : IDbService
{
    public async Task<RacerGetDTO> GetRacerDetailsAsync(int id)
    {
        var racer = await dbContext.Racers
            .Where(r => r.RacerId == id)
            .Select(r => new RacerGetDTO
            {
                RacerId = r.RacerId,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Participations = r.RaceParticipations
                    .Select(rp => new RaceParticipationDTO
                    {
                        Race = new RaceInfoDTO
                        {
                            Name = rp.TrackRace.Race.Name,
                            Location = rp.TrackRace.Race.Location,
                            Date = rp.TrackRace.Race.Date
                        },
                        Track = new TrackInfoDTO
                        {
                            Name = rp.TrackRace.Track.Name,
                            LengthInKm = rp.TrackRace.Track.LengthInKm
                        },
                        Laps = rp.TrackRace.Laps,
                        FinishTimeInSeconds = rp.FinishTimeInSeconds,
                        Position = rp.Position
                    }).ToList()
            })
            .FirstOrDefaultAsync();

        if (racer == null)
            throw new NotFoundException("Racer not found");

        return racer;
    }

    public async Task GetNewTrackDataAsync(GetTrackRaceDataDTO data)
    {
        var race = await dbContext.Races
            .FirstOrDefaultAsync(r => r.Name == data.RaceName);
        if (race == null)
            throw new NotFoundException($"Race '{data.RaceName}' not found.");
        
        var track = await dbContext.Tracks
            .FirstOrDefaultAsync(t => t.Name == data.TrackName);
        if (track == null)
            throw new NotFoundException($"Track '{data.TrackName}' not found.");
        
        var trackRace = await dbContext.TrackRaces
            .FirstOrDefaultAsync(tr => tr.RaceId == race.RaceId && tr.TrackId == track.TrackId);
        if (trackRace == null)
            throw new NotFoundException($"TrackRace with race '{data.RaceName}' and track '{data.TrackName}' not found.");
        
        foreach (var p in data.Participations)
        {
            var racer = await dbContext.Racers.FirstOrDefaultAsync(r => r.RacerId == p.RacerId);
            if (racer == null)
                throw new NotFoundException($"Racer with ID {p.RacerId} not found.");
            var participation = new Race_Participation
            {
                TrackRaceId = trackRace.TrackRaceId,
                RacerId = p.RacerId,
                FinishTimeInSeconds = p.FinishTimeInSeconds,
                Position = p.Position
            };
            dbContext.RaceParticipations.Add(participation);
            
            if (!trackRace.BestTimeInSeconds.HasValue || p.FinishTimeInSeconds < trackRace.BestTimeInSeconds)
            {
                trackRace.BestTimeInSeconds = p.FinishTimeInSeconds;
            }
        }

        await dbContext.SaveChangesAsync();
    }
}