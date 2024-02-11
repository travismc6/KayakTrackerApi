using KayakTracker.Application.Services;
using KayakTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using KayakTracker.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace KayakTracker.Application.Services
.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripsController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var trips = await _tripService.GetTripList(User.Identity.Name);

            return Ok(trips);
        }

        [HttpPut]
        public IActionResult ImportTrips()
        {
            return Ok();
        }
    }
}
