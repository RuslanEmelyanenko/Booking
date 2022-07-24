using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Repository.Implementations;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class BookingConfirmationService : IBaseService<BookingConfirmationDto>, IBookingConfirmationService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingConfirmationService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<BookingConfirmationDto>> GatAllAsync()
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
    }
}