using Booking.Models;
using Booking.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository.Implementations
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected DbSet<T> Entities { get; set; }
        protected BookingDBContext DbContext { get; set; }

        protected BaseRepository(BookingDBContext dbContext)
        {
            DbContext = dbContext;
            Entities = dbContext.Set<T>();
        }

        public async Task CompleteAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await Entities.AddAsync(entity);
        }

        public void CreateList(IReadOnlyCollection<T> entities)
        {
            Entities.AddRange(entities);
        }

        public async Task DeleteAsync(T entity)
        {         
            Entities.Remove(entity);
        }

        public async Task GetAsync(T entity)
        {
            await Entities.FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            DbContext.Update(entity);
        }
    }
}