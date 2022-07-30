using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Repository.Implementations;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class DistrictService : IBaseService<DistrictDto>, IDistrictService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public DistrictService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<DistrictDto>> GatAllAsync()
        {
            var districts = await _unitOfWork.DistrictRepository.GetAllAsync();
            var districtsDto = _mapper.Map<List<DistrictDto>>(districts);

            return districtsDto;
        }

        public async Task<DistrictDto> GetAsync(string entity)
        {
            var district = await _unitOfWork.DistrictRepository.GetAsync(entity);
            var districtDto = _mapper.Map<DistrictDto>(district);

            return districtDto;
        }
    }
}