using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Models;
using Booking.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        private readonly BookingDBContext _dbContext;

        public ApartmentRepository(BookingDBContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Apartment> GetAsync(string apartmentName)
        {
            var apartment = await _dbContext.Apartments.FirstOrDefaultAsync(a => a.ApartmentName == apartmentName);

            return apartment;
        }

        public async Task<List<Apartment>> GetAllAsync()
        {
            var apartments = await _dbContext.Apartments.ToListAsync();

            return apartments;
        }
    }
}