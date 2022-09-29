using Booking.Models;
using Booking.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class DistrictRepository : BaseRepository<District>, IDistrictRepository
    {
        private readonly BookingDBContext _dbContext;

        public DistrictRepository(BookingDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<District> GetAsync(string districtName)
        {
            var district = await _dbContext.Districts.FirstOrDefaultAsync(d => d.DistrictName == districtName);

            return district;
        }

        public async Task<IReadOnlyCollection<District>> GetAllAsync()
        {
            var districts = await _dbContext.Districts.ToListAsync();
                   
            return districts;
        }

        public async Task<District> GetAsync(int id)
        {
            var district = await _dbContext.Districts.FirstOrDefaultAsync(d => d.Id == id);

            return district;
        }

        public async Task Delete(int id)
        {
            var district = await _dbContext.Districts.FindAsync(id);

            if(district != null)
            {
                _dbContext.Remove(district);
            }
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}