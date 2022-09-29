namespace Booking.Services.Abstraction
{
    public interface IBaseService<T> 
        where T : class 
    {
        Task<T> GetAsync(string entity);
        Task<IReadOnlyCollection<T>> GatAllAsync();
        Task<T> GetAsync(int id);
        Task DeleteItemAsync(int id);
        Task CreateItemAsync(T entity);
    }
}