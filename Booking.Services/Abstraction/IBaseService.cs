using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Services.Abstraction
{
    public interface IBaseService<T> 
        where T : class 
    {
        Task<T> GetAsync(string entity);
        Task<IList<T>> GatAllAsync();
    }
}