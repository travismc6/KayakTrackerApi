using KayakTracker.Domain.Enums;
using KayakTracker.Domain.Models;

namespace KayakTracker.Infrastructure
{
    public interface ITripRepository
    {
        public Task<List<Trip>> GetTrips(string userName);

        public Task<bool> SaveTrips(List<Trip> trips);

        public River GetRiver(string riverName, StateEnum state);
    }
}
