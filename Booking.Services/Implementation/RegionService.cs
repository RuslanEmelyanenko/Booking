using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Repository.Implementations;

namespace Booking.Services.Abstraction
{
    public class RegionService : IBaseService<RegionDto>, IRegionService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegionService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<RegionDto>> GatAllAsync()
        {
            var regiones = await _unitOfWork.RegionRepository.GetAllAsync();
            var regionesDto = _mapper.Map<List<RegionDto>>(regiones);

            return regionesDto;
        }

        public async Task<RegionDto> GetAsync(string entity)
        {
            var region = await _unitOfWork.RegionRepository.GetAsync(entity);
            var regionDto = _mapper.Map<RegionDto>(region);

            return regionDto;
        }
    }
}