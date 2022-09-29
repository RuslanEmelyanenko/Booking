using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Models;
using Booking.Repository.Abstractions;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class BookingConfirmationService : IBaseService<BookingConfirmationDto>, IBookingConfirmationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingConfirmationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<BookingConfirmationDto>> GatAllAsync()
        {
            var bookingConfirmations = await _unitOfWork.BookingConfirmationsRepository.GetAllAsync();
            var bookingConfirmationDto = _mapper.Map<List<BookingConfirmationDto>>(bookingConfirmations);

            return bookingConfirmationDto;
        }

        public async Task<BookingConfirmationDto> GetAsync(string entity)
        {
            var bookingConfirmation = await _unitOfWork.BookingConfirmationsRepository.GetAsync(entity);
            var bookingConfirmationDto = _mapper.Map<BookingConfirmationDto>(bookingConfirmation);

            return bookingConfirmationDto;
        }

        public async Task<BookingConfirmationDto> GetAsync(int id)
        {
            var bookingConfirmation = await _unitOfWork.BookingConfirmationsRepository.GetAsync(id);
            var bookingConfirmationDto = _mapper.Map<BookingConfirmationDto>(bookingConfirmation);

            return bookingConfirmationDto;
        }

        public async Task DeleteItemAsync(int id)
        {
            BookingConfirmation bookingConfirmation = await _unitOfWork.BookingConfirmationsRepository.GetAsync(id); 

            if (bookingConfirmation != null)
            {
                await _unitOfWork.BookingConfirmationsRepository.DeleteAsync(id);
                await _unitOfWork.BookingConfirmationsRepository.CompleteAsync();
            }
        }

        public async Task CreateItemAsync(BookingConfirmationDto createBookingConfirmation)
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            var customer = customers.FirstOrDefault(c => c.Name == createBookingConfirmation.CustomerName
            && c.Surname == createBookingConfirmation.CustomerSurname 
            && c.PhoneNumber == createBookingConfirmation.PhoneNumber);
            //var apartments = await _unitOfWork.ApartmentRepository.GetAllAsync();
            //var apartment = apartments.FirstOrDefault(a => a.ApartmentName == createBookingConfirmation.ApartmentName);
            var apartment = await _unitOfWork.ApartmentRepository.GetAsync(createBookingConfirmation.ApartmentName);

            if (customer == null)
            {
                customer = new Customer
                {
                    Name = createBookingConfirmation.CustomerName,
                    Surname = createBookingConfirmation.CustomerSurname,
                    PhoneNumber = createBookingConfirmation.PhoneNumber,
                    Email = createBookingConfirmation.Email
                };
            }

            var bookingConfirmation = new BookingConfirmation
            {
                BookingDate = createBookingConfirmation.BookingDate,
                Apartment = apartment,
                Customer = customer,
                IsApproved = createBookingConfirmation.IsApproved
            };

            await _unitOfWork.BookingConfirmationsRepository.CreateAsync(bookingConfirmation);
            await _unitOfWork.BookingConfirmationsRepository.CompleteAsync();
        }

        public async Task UpdateAsync(BookingConfirmationDto updateBookingConfirmation)
        {
            //var bookingConfirmations = await _unitOfWork.BookingConfirmationsRepository.GetAllAsync();
            //var bookingConfirmation = bookingConfirmations.FirstOrDefault(
            //    b => b.Apartment.ApartmentName == updateBookingConfirmation.ApartmentName
            //    && b.Customer.Name == updateBookingConfirmation.CustomerName
            //    && b.Customer.Surname == updateBookingConfirmation.CustomerSurname
            //    && b.Customer.PhoneNumber == updateBookingConfirmation.PhoneNumber);

            var apartments = await _unitOfWork.ApartmentRepository.GetAllAsync();
            var apartment = apartments.FirstOrDefault(a => a.ApartmentName == updateBookingConfirmation.ApartmentName);
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            var customer = customers.FirstOrDefault(
                c => c.Name == updateBookingConfirmation.CustomerName
                && c.Surname == updateBookingConfirmation.CustomerSurname
                && c.PhoneNumber == updateBookingConfirmation.PhoneNumber);
            var bookingConfirmations = await _unitOfWork.BookingConfirmationsRepository.GetAllAsync();
            var bookingConfirmation = bookingConfirmations.FirstOrDefault(d => d.BookingDate == updateBookingConfirmation.BookingDate);

            apartment.ApartmentName = updateBookingConfirmation.ApartmentName;
            customer.Name = updateBookingConfirmation.CustomerName;
            customer.Surname = updateBookingConfirmation.CustomerSurname;
            customer.PhoneNumber = updateBookingConfirmation.PhoneNumber;
            customer.Email = updateBookingConfirmation.Email;
            bookingConfirmation.BookingDate = updateBookingConfirmation.BookingDate;
            bookingConfirmation.IsApproved = updateBookingConfirmation.IsApproved;
            
            await _unitOfWork.BookingConfirmationsRepository.CompleteAsync();
        }
    }
}