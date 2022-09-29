using Booking.Models;
using Booking.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        private readonly BookingDBContext _dbContext;

        public LocationRepository(BookingDBContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Location> GetAsync(string locationName)
        {
            var location = await _dbContext.Locations.FirstOrDefaultAsync(l => l.Pleace == locationName);

            return location;
        }

        public async Task<IReadOnlyCollection<Location>> GetAllAsync()
        {
            var locations = await _dbContext.Locations
                .Include(l => l.District)
                .ToListAsync();

            return locations;
        }

        public async Task<Location> GetAsync(int id)
        {
            var location = await _dbContext.Locations.FirstOrDefaultAsync(l => l.Id == id);

            return location;
        }

        public async Task Delete(int id)
        {
            var location = await _dbContext.Locations.FindAsync(id);

            if(location != null)
            {
                _dbContext.Remove(location);
            }
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Location location)
        {
            _dbContext.Locations.Update(location);
        }
    }
}