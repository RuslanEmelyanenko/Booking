using Booking.Repository.Implementations;

namespace Booking.Repository.Abstractions
{
    public interface IUnitOfWork
    {
        public ApartmentRepository ApartmentRepository { get; }
        public BookingConfirmationsRepository BookingConfirmationsRepository { get; }
        public CountryRepository CountryRepository { get; }
        public CustomerRepository CustomerRepository { get; }
        public DistrictRepository DistrictRepository { get; }
        public LocationRepository LocationRepository { get; }
        public RegionRepository RegionRepository { get; }
    }
}