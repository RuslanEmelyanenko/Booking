using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Models;
using Booking.Repository.Abstractions;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class LocationService : IBaseService<LocationDto>, ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<LocationDto>> GatAllAsync()
        {
            var locations = await _unitOfWork.LocationRepository.GetAllAsync();
            var locationsDto = _mapper.Map<IReadOnlyCollection<LocationDto>>(locations);

            return locationsDto;
        }

        public async Task<LocationDto> GetAsync(string entity)
        {
            Location location = await _unitOfWork.LocationRepository.GetAsync(entity);
            LocationDto locationDto = _mapper.Map<LocationDto>(location);

            return locationDto;
        }

        public async Task<LocationDto> GetAsync(int id)
        {
            Location location = await _unitOfWork.LocationRepository.GetAsync(id);
            LocationDto locationDto = _mapper.Map<LocationDto>(location);

            return locationDto;
        }

        public async Task DeleteItemAsync(int id)
        {
            Location location = await _unitOfWork.LocationRepository.GetAsync(id);

            if(location != null)
            {
                await _unitOfWork.LocationRepository.Delete(id);
                await _unitOfWork.LocationRepository.CompleteAsync();
            }
        }

        public Task CreateItemAsync(LocationDto entity)
        {
            throw new NotImplementedException();
        }
    }
}