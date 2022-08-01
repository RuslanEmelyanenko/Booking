using Booking.Repository.Implementations;

namespace Booking.Repository.Abstractions
{
    public interface IUnitOfWork
    {
        public ApartmentRepository ApartmentRepository { get; }
    }
}