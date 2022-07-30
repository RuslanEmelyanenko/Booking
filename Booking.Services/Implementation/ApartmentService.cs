using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Repository.Implementations;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class ApartmentService : IBaseService<ApartmentDto>, IApartmentService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApartmentService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<ApartmentDto>> GatAllAsync()
        {
            var apartments = await _unitOfWork.ApartmentRepository.GetAllAsync();
            var apartmentsDto = _mapper.Map<List<ApartmentDto>>(apartments);

            return apartmentsDto;
        }

        public async Task<ApartmentDto> GetAsync(string apartmentName)
        {
            var apartment = await _unitOfWork.ApartmentRepository.GetAsync(apartmentName);
            var apartmentDto = _mapper.Map<ApartmentDto>(apartment);

            return apartmentDto;
        }
    }                                                                                        
}