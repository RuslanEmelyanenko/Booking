namespace Booking.Repository.Abstractions
{
    internal interface IBaseRepository<T>
        where T : class
    {
        Task<IList<T>> GetAllAsync();

        Task  GetAsync(T entity);

        void Create(T entity);

        void CreateList(IList <T> entities);

        void Update(T entity);

        void Delete(T entity);

        void Complete();
    }
}