using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        private readonly BookingDBContext _dbContext;

        public CustomerRepository(BookingDBContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<Customer> GetAsync(string customerName, string customerSurname)
        {
            var customer = await _dbContext.Customers.Where(cn => cn.Name == customerName).FirstOrDefaultAsync(cs => cs.Surname == customerSurname);

            return customer;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customers = await _dbContext.Customers.ToListAsync();

            return customers;
        }
    }
}