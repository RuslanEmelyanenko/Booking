using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class RegionRepository : BaseRepository<Region>
    {
        private readonly BookingDBContext _dbContext;

        public RegionRepository(BookingDBContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Region> GetAsync(string regionName)
        {
            var region = await _dbContext.Regions.FirstOrDefaultAsync(r => r.RegionName == regionName);

            return region;
        }

        public async Task<IList<Region>> GetAllAsync()
        {
            var regions = await _dbContext.Regions.ToListAsync();

            return regions;
        }
    }
}