using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Models;
using Booking.Repository.Abstractions;
using Booking.Repository.Implementations;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class DistrictService : IBaseService<DistrictDto>, IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public DistrictService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<DistrictDto>> GatAllAsync()
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

        public async Task<DistrictDto> GetAsync(int id)
        {
            var district = await _unitOfWork.DistrictRepository.GetAsync(id);
            var districtDto = _mapper.Map<DistrictDto>(district);

            return districtDto;
        }

        public async Task DeleteItemAsync(int id)
        {
            District district = await _unitOfWork.DistrictRepository.GetAsync(id);

            if(district != null)
            {
                await _unitOfWork.DistrictRepository.Delete(id);
                await _unitOfWork.DistrictRepository.CompleteAsync();
            }
        }

        public Task CreateItemAsync(DistrictDto entity)
        {
            throw new NotImplementedException();
        }
    }
}