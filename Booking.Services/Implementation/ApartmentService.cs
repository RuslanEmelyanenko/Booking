using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Models;
using Booking.Repository.Abstractions;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class ApartmentService : IBaseService<ApartmentDto>, IApartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<ApartmentDto>> GatAllAsync()
        {
            var apartments = await _unitOfWork.ApartmentRepository.GetAllAsync();
            var apartmentsDto = _mapper.Map<IReadOnlyCollection<ApartmentDto>>(apartments);

            return apartmentsDto;
        }

        public async Task<ApartmentDto> GetAsync(string apartmentName)
        {
            var apartment = await _unitOfWork.ApartmentRepository.GetAsync(apartmentName);
            var apartmentDto = _mapper.Map<ApartmentDto>(apartment);

            return apartmentDto;
        }

        public async Task<ApartmentDto> GetAsync(int id)
        {
            var apartment = await _unitOfWork.ApartmentRepository.GetAsync(id);
            var apartmentDto = _mapper.Map<ApartmentDto>(apartment);

            return apartmentDto;
        }

        public async Task DeleteItemAsync(string apartmentName)
        {
            Apartment apartment = await _unitOfWork.ApartmentRepository.GetAsync(apartmentName);
            
            if (apartment != null)
            {
                await _unitOfWork.ApartmentRepository.Delete(apartmentName);
                await _unitOfWork.ApartmentRepository.CompleteAsync();
            }
        }

        public async Task CreateItemAsync(ApartmentDto createApartment)
        {
            var locations = await _unitOfWork.LocationRepository.GetAllAsync();
            var location = locations.FirstOrDefault(l => l.Pleace == createApartment.LocationPleace && l.District.DistrictName == createApartment.DistrictName);

            if(location == null)
            {
                var district = await _unitOfWork.DistrictRepository.GetAsync(createApartment.DistrictName);

                location = new Location
                {
                    Pleace = createApartment.LocationPleace,
                    District = district
                };
            }

            var apartment = new Apartment
            {
                ApartmentName = createApartment.ApartmentName,
                PhotoApartment = createApartment.PhotoAppartment,
                Reviews = createApartment.Reviews,
                Gpa = createApartment.GPA,
                Location = location
            };

            await _unitOfWork.ApartmentRepository.CreateAsync(apartment);
            await _unitOfWork.ApartmentRepository.CompleteAsync(); 
        }

        public async Task UpdateAsync(ApartmentDto updateApartment)
        {
            var locations = await _unitOfWork.LocationRepository.GetAllAsync();
            var location = locations.FirstOrDefault(l => l.Pleace == updateApartment.LocationPleace);
            var districts = await _unitOfWork.DistrictRepository.GetAllAsync();
            var district = districts.FirstOrDefault(d => d.DistrictName == updateApartment.DistrictName);
            var apartments = await _unitOfWork.ApartmentRepository.GetAllAsync();
            var apartment = apartments.FirstOrDefault(a => a.ApartmentName == updateApartment.ApartmentName);

            location.Pleace = updateApartment.LocationPleace;
            district.DistrictName = updateApartment.DistrictName;
            apartment.ApartmentName = updateApartment.ApartmentName;
            apartment.PhotoApartment = updateApartment.PhotoAppartment;
            apartment.Reviews = updateApartment.Reviews;
            apartment.Gpa = updateApartment.GPA;

            await _unitOfWork.ApartmentRepository.CompleteAsync();
        }

        public Task DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }
    }                                                                                        
}