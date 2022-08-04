using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class CountryRepository : BaseRepository<Country>
    {
        private readonly BookingDBContext _dbContext;

        public CountryRepository(BookingDBContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Country> GetAsync(string countryName)
        {
            var country = await _dbContext.Countries.FirstOrDefaultAsync(c => c.CountryName == countryName);

            return country;
        }

        public async Task<IList<Country>> GetAllAsync()
        {
            var countries = await _dbContext.Countries.ToListAsync();

            return countries;
        }
    }
}