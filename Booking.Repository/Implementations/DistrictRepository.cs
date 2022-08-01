using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class DistrictRepository : BaseRepository<District>
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

        public async Task<IList<District>> GetAllAsync()
        {
            var districts = await _dbContext.Districts.ToListAsync();
                   
            return districts;
        }
    }
}