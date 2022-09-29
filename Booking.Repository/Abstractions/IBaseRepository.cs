namespace Booking.Repository.Abstractions
{
    internal interface IBaseRepository<T>
        where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();

        Task  GetAsync(T entity);

        Task CreateAsync(T entity);

        void CreateList(IReadOnlyCollection<T> entities);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task CompleteAsync();
    }
}