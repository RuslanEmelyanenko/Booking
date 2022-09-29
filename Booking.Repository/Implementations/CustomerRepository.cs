using Booking.Models;
using Booking.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
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

        public async Task<IReadOnlyCollection<Customer>> GetAllAsync()
        {
            var customers = await _dbContext.Customers.ToListAsync();

            return customers;
        }

        public async Task<Customer> GetAsync(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(b => b.Id == id);

            return customer;
        }

        public async Task Delete(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);

            if (customer != null)
            {
                _dbContext.Remove(customer);
            }
        }

        public async Task TaskAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _dbContext.Customers.Update(customer);
        }
    }
}