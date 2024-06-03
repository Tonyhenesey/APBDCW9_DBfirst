using APBD__Cwiczenia9.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD.Controllrs;

[ApiController]
[Route("api/[Controller]")]
public class TripsController : ControllerBase
{
    private readonly ApbdCw08Context _context;

    public TripsController(ApbdCw08Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        var trips = await _context.Trips
            .Select(e => new
            {
                Name = e.Name,
                Countries = e.IdCountries.Select(c => new
                {
                    Name = c.Name
                })
            })
            .ToListAsync();

        return Ok(trips);
    }

}