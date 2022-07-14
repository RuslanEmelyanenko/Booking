using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Repository.Implementations;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class AppartmentService : IBaseService<AppartmentDto>, IAppartmentService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppartmentService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<AppartmentDto>> GatAllAsync()
        {
            var appartments = await _unitOfWork.AppartmentRepository.GetAllAsync();
            var appartmentsDto = new List<AppartmentDto>();

            foreach (var appartment in appartments)
            {
                var appartmentItem = new AppartmentDto
                {
                    AppartmentName = appartment.AppartmentName,
                    PhotoAppartment = appartment.PhotoAppartment,
                    Reviews = appartment.Reviews,
                    GPA = appartment.Gpa, 
                };

                appartmentsDto.Add(appartmentItem);
            }
                                                                                          

            return appartmentsDto;
        }

        public async Task<AppartmentDto> GetAsync(string appartmentName)
        {
            var appartment = await _unitOfWork.AppartmentRepository.GetAsync(appartmentName);

            var appartmentDto = new AppartmentDto()
            {
                AppartmentName = appartment.AppartmentName,
                PhotoAppartment = appartment.PhotoAppartment,
                Reviews = appartment.Reviews,
                GPA = appartment.Gpa,
            };

            return appartmentDto;
        }
    }
}