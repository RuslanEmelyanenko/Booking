using System;
using System.Threading.Tasks;
using Booking.Models;
using Booking.Repository.Abstractions;

namespace Booking.Repository.Implementations
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private BookingDBContext dbContext = new BookingDBContext();
        private ApartmentRepository _apartmentRepository;
        private BookingConfirmationsRepository _bookingConfirmationsRepository;
        private CountryRepository _countryRepository;
        private CustomerRepository _customerRepository;
        private DistrictRepository _districtRepository;
        private LocationRepository _locationRepository;
        private RegionRepository _regionRepository;

        public ApartmentRepository ApartmentRepository
        {
            get { return _apartmentRepository ??= new ApartmentRepository(dbContext); }
        }

        public BookingConfirmationsRepository BookingConfirmationsRepository
        {
            get
            {
                if(_bookingConfirmationsRepository == null)
                {
                    _bookingConfirmationsRepository = new BookingConfirmationsRepository(dbContext);
                }
                return _bookingConfirmationsRepository;
            }
        }

        public CountryRepository CountryRepository
        {
            get
            {
                if(_countryRepository == null)
                {
                    _countryRepository = new CountryRepository(dbContext);
                }
                return _countryRepository;
            }
        }

        public CustomerRepository CustomerRepository
        {
            get
            {
                if(_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(dbContext);
                }
                return _customerRepository;
            }
        }

        public DistrictRepository DistrictRepository
        {
            get
            {
                if(_districtRepository == null)
                {
                    _districtRepository = new DistrictRepository(dbContext);
                }
                return _districtRepository;
            }
        }

        public LocationRepository LocationRepository
        {
            get
            {
                if(_locationRepository == null)
                {
                    _locationRepository = new LocationRepository(dbContext);
                }
                return _locationRepository;
            }
        }

        public RegionRepository RegionRepository
        {
            get
            {
                if(_regionRepository == null)
                {
                    _regionRepository = new RegionRepository(dbContext);
                }
                return _regionRepository;
            }
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}