using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Repository.Implementations;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class CountryService : IBaseService<CountryDto>, ICountryService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<CountryDto>> GatAllAsync()
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
    }
}