using Booking.Models;
using Booking.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
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

        public async Task<IReadOnlyCollection<Region>> GetAllAsync()
        {
            var regions = await _dbContext.Regions.ToListAsync();

            return regions;
        }

        public async Task<Region> GetAsync(int id)
        {
            var region = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            return region;
        }

        public async Task Delete(int id)
        {
            var region = await _dbContext.Regions.FindAsync(id);

            if(region != null)
            {
                _dbContext.Remove(region);
            }
        }

        public async Task ComleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}