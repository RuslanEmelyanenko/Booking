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
            var apartmentsDto = new List<ApartmentDto>();

            foreach (var apartment in apartments)
            {
                var apartmentItem = new ApartmentDto
                {
                    ApartmentName = apartment.ApartmentName,
                    PhotoAppartment = apartment.PhotoAppartment,
                    Reviews = apartment.Reviews,
                    GPA = apartment.Gpa, 
                };

                apartmentsDto.Add(apartmentItem);
            }
                                                                                          

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