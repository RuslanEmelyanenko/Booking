using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Models;
using Booking.Repository.Abstractions;
using Booking.Repository.Implementations;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class CountryService : IBaseService<CountryDto>, ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<CountryDto>> GatAllAsync()
        {
            var countries = await _unitOfWork.CountryRepository.GetAllAsync();
            var countriesDto = _mapper.Map<List<CountryDto>>(countries);

            return countriesDto;
        }

        public async Task<CountryDto> GetAsync(string countryName)
        {
            var country = await _unitOfWork.CountryRepository.GetAsync(countryName);
            var countryDto = _mapper.Map<CountryDto>(country);

            return countryDto;
        }

        public async Task<CountryDto> GetAsync(int id)
        {
            var country = await _unitOfWork.CountryRepository.GetAsync(id);
            var countryDto = _mapper.Map<CountryDto>(country);

            return countryDto;
        }

        public async Task DeleteItemAsync(int id)
        {
            Country country = await _unitOfWork.CountryRepository.GetAsync(id);

            if(country != null)
            {
                await _unitOfWork.CountryRepository.Delete(id);
                await _unitOfWork.CountryRepository.CompleteAsync();
            }
        }

        public Task CreateItemAsync(CountryDto entity)
        {
            throw new NotImplementedException();
        }
    }
}