using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Repository.Implementations;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class LocationService : IBaseService<LocationDto>, ILocationService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<LocationDto>> GatAllAsync()
        {
            var locations = await _unitOfWork.LocationRepository.GetAllAsync();
            var locationsDto = _mapper.Map<List<LocationDto>>(locations);

            return locationsDto;
        }

        public async Task<LocationDto> GetAsync(string entity)
        {
            var location = await _unitOfWork.LocationRepository.GetAsync(entity);
            var locationDto = _mapper.Map<LocationDto>(location);

            return locationDto;
        }
    }
}