using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Models;
using Booking.Repository.Abstractions;
using Booking.Repository.Implementations;

namespace Booking.Services.Abstraction
{
    public class RegionService : IBaseService<RegionDto>, IRegionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<RegionDto>> GatAllAsync()
        {
            var regiones = await _unitOfWork.RegionRepository.GetAllAsync();
            var regionesDto = _mapper.Map<IReadOnlyCollection<RegionDto>>(regiones);

            return regionesDto;
        }

        public async Task<RegionDto> GetAsync(string entity)
        {
            var region = await _unitOfWork.RegionRepository.GetAsync(entity);
            var regionDto = _mapper.Map<RegionDto>(region);

            return regionDto;
        }

        public async Task<RegionDto> GetAsync(int id)
        {
            var region = await _unitOfWork.RegionRepository.GetAsync(id);
            var regionDto = _mapper.Map<RegionDto>(region);

            return regionDto;
        }

        public async Task DeleteItemAsync(int id)
        {
            Region region = await _unitOfWork.RegionRepository.GetAsync(id);

            if(region != null)
            {
                await _unitOfWork.RegionRepository.Delete(id);
                await _unitOfWork.RegionRepository.ComleteAsync(); 
            }
        }

        public Task CreateItemAsync(RegionDto entity)
        {
            throw new NotImplementedException();
        }
    }
}