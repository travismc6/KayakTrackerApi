using KayakTracker.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KayakTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ITripService _tripService;

        public AdminController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpPost]
        [Route("import")]
        public async Task<IActionResult> ImportTrips(IFormFile file)
        {
            var userId = User.Identity.Name; //"60b22fe6-cb72-4954-889c-0d9d5d51fe97";

            var trips = await _tripService.Import(file, userId);

            return Ok(trips);
        }
    }
}
