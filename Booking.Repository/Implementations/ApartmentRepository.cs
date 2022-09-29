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
            var apartment = await _dbContext.Apartments.FindAsync(apartmentName);

            return apartment; 
        }

        public async Task<IReadOnlyCollection<Apartment>> GetAllAsync() 
        {
            var apartments = await _dbContext.Apartments
                .Include(a => a.Location)
                .ToListAsync();

            return apartments;
        }

        public async Task<Apartment> GetAsync(int id)
        {
            var apartment = await _dbContext.Apartments.FirstOrDefaultAsync(b => b.Id == id);

            return apartment;
        }

        public async Task Delete(string apartmentName)
        {
            var apartment = await _dbContext.Apartments.FindAsync(apartmentName);

            if (apartment != null)
            {
                _dbContext.Remove(apartment);
            }
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
        }

        public async Task CreateAsync(Apartment apartment)
        {
            await _dbContext.Apartments.AddAsync(apartment);
        }

        public async Task UpdateAsync(Apartment apartment)
        {
            _dbContext.Apartments.Update(apartment);
        }
    }
}