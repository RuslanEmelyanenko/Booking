using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class BookingConfirmationsRepository : BaseRepository<BookingConfirmation>
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

        public async Task<List<BookingConfirmation>> GetAllAsync()
        {
            var bookingConfirmations = await _dbContext.BookingConfirmations.ToListAsync();

            return bookingConfirmations;
        }

        public async Task<BookingConfirmation> GetAsync(string customerName)
        {
            var bookingConfirmation = await _dbContext.BookingConfirmations.FirstOrDefaultAsync(b => b.Customer.Name == customerName);

            return bookingConfirmation;
        }
    }
}