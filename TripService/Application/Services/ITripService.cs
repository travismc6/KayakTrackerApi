using KayakTracker.Application.DTOs;
using KayakTracker.Domain.Models;

namespace KayakTracker.Application.Services
{
    public interface ITripService
    {
        public Task<List<TripDto>> GetTripList(string userName);

        Task<List<Trip>> Import(IFormFile file, string userId);
    }
}
