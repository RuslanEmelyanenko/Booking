using Booking.Models;
using Booking.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
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

        public async Task<IReadOnlyCollection<Country>> GetAllAsync()
        {
            var countries = await _dbContext.Countries.ToListAsync();

            return countries;
        }

        public async Task<Country> GetAsync(int id)
        {
            var country = await _dbContext.Countries.FirstOrDefaultAsync(b => b.Id == id);

            return country;
        }

        public async Task Delete(int id)
        {
            var country = await _dbContext.Countries.FindAsync(id);

            if (country != null)
            {
                _dbContext.Remove(country);
            }
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}