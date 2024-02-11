using Microsoft.EntityFrameworkCore;
using KayakTracker.Domain.Models;
using KayakTracker.Domain.Enums;

namespace KayakTracker.Infrastructure
{
    public class TripRepository : ITripRepository
    {
        private readonly TripDbContext _context;

        public TripRepository(TripDbContext context)
        {
            _context = context;
        }

        public River GetRiver(string riverName, StateEnum stateEnum)
        {
            var river = _context.Rivers.FirstOrDefault(r => r.Name.ToLower() == riverName.ToLower());

            if (river == null)
            {
                river = new River()
                {
                    Name = riverName,
                    State = stateEnum,
                };

                _context.Rivers.Add(river);
                _context.SaveChanges();
            }

            return river;
        }

        public async Task<List<Trip>> GetTrips(string userName)
        {
            return await _context.Trips.Where(r => r.OwnerId == userName).Include(r=> r.River).ToListAsync();
        }

        public async Task<bool> SaveTrips(List<Trip> trips)
        {
            await _context.Trips.AddRangeAsync(trips);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
