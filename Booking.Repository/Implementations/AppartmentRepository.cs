using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class AppartmentRepository : BaseRepository<Appartment>
    {
        private readonly BookingDBContext _dbContext;

        public AppartmentRepository(BookingDBContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Appartment> GetAsync(string appartmentName)
        {
            var appartment = await _dbContext.Appartments.FirstOrDefaultAsync(a => a.AppartmentName == appartmentName);

            return appartment;
        }

        public async Task<List<Appartment>> GetAllAsync()
        {
            var appartments = await _dbContext.Appartments.ToListAsync();

            return appartments;
        }
    }
}