using System.ComponentModel.DataAnnotations;
using KolokwiumAPBD_2.Exceptions;
using KolokwiumAPBD_2.Models.DTOs;
using KolokwiumAPBD_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumAPBD_2.Controllers;

[ApiController]
[Route("api")]
public class RacersController(IDbService service) : ControllerBase
{
    [HttpGet]
    [Route("racers/{id}/participations")]
    public async Task<IActionResult> GetRacerDetails([FromRoute] int id)
    {
        try
        {
            return Ok(await service.GetRacerDetailsAsync(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    [Route("track-races/participants")]
    public async Task<IActionResult> GetNewTrackData([FromBody] GetTrackRaceDataDTO data)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data.");
        try
        {
            await service.GetNewTrackDataAsync(data);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }
}