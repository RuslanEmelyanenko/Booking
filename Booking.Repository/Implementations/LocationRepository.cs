using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class LocationRepository : BaseRepository<Location>
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

        public async Task<IList<Location>> GetAllAsync()
        {
            var locations = await _dbContext.Locations.ToListAsync();

            return locations;
        }
    }
}