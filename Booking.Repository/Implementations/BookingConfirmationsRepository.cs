using Booking.Models;
using Booking.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class BookingConfirmationsRepository : BaseRepository<BookingConfirmation>, IBookingConfirmationsRepository
    {
        private readonly BookingDBContext _dbContext;

        public BookingConfirmationsRepository(BookingDBContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookingConfirmation> GetAsync(DateTime bookingDate)
        {
            var date = await _dbContext.BookingConfirmations.FirstOrDefaultAsync(b => b.BookingDate == bookingDate);

            return date;
        }

        public async Task<IReadOnlyCollection<BookingConfirmation>> GetAllAsync()
        {
            var bookingConfirmations = await _dbContext.BookingConfirmations
                .Include(b => b.Apartment)
                .Include(b => b.Customer)
                .ToListAsync();

            return bookingConfirmations;
        }

        public async Task<BookingConfirmation> GetAsync(string customerName)
        {
            var bookingConfirmation = await _dbContext.BookingConfirmations.FirstOrDefaultAsync(b => b.Customer.Name == customerName);

            return bookingConfirmation;
        }

        public async Task<BookingConfirmation> GetAsync(int id)
        {
            var bookingConfirmation = await _dbContext.BookingConfirmations.FirstOrDefaultAsync(b => b.Id == id);

            return bookingConfirmation;
        }

        public async Task DeleteAsync(int id)
        {
            var bookingConfirmation = _dbContext.BookingConfirmations.Find(id);

            if (bookingConfirmation != null)
            {
                _dbContext.Remove(bookingConfirmation);
            }
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(BookingConfirmation bookingConfirmation)
        {
            await _dbContext.BookingConfirmations.AddAsync(bookingConfirmation);
        }

        public async Task UpdateAsync(BookingConfirmation bookingConfirmation)
        {
            _dbContext.BookingConfirmations.Update(bookingConfirmation);
        }
    }
}