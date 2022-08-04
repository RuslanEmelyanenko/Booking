using System.Collections.Generic;
using System.Threading.Tasks;
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

        public void Complete()
        {
            DbContext.SaveChanges();
        }

        public void Create(T entity)
        {
            Entities.Add(entity);
        }

        public void CreateList(IList<T> entities)
        {
            Entities.AddRange(entities);
        }

        public void Delete(T entity)
        {
            Entities.Remove(entity);
        }

        public async Task GetAsync(T entity)
        {
            await Entities.FirstOrDefaultAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public void Update(T entity)
        {
            DbContext.Update(entity);
        }
    }
}