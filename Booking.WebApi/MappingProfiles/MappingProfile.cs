using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Models;

namespace Booking.WebApi.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AddApartmentsProfileMapping();
            AddBookingConfirmationProfileMapping();
            AddCountryProfileMapping();
            AddCustomerProfileMapping();
            AddDistrictNameProfileMapping();
            AddLocationProfileMapping();
            AddRegionProfileMapping();
            AddUserInfoProfileMapping();
        }

        public void AddApartmentsProfileMapping()
        {
            CreateMap<Apartment, ApartmentDto>()
                .ForMember(dest => dest.ApartmentName, opt => opt.MapFrom(src => src.ApartmentName))
                .ForMember(dest => dest.PhotoAppartment, opt => opt.MapFrom(src => src.PhotoAppartment))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
                .ForMember(dest => dest.GPA, opt => opt.MapFrom(src => src.Gpa));
        }

        public void AddBookingConfirmationProfileMapping()
        {
            CreateMap<BookingConfirmation, BookingConfirmationDto>()
                .ForMember(dest => dest.ApartmentName, opt => opt.MapFrom(src => src.Apartment.ApartmentName))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.CustomerSurname, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Customer.Email))
                .ForMember(dest => dest.IsApproved, opt => opt.MapFrom(src => src.IsApproved));
        }

        public void AddCountryProfileMapping()
        {
            CreateMap<Country, CountryDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.CountryName));
        }

        public void AddCustomerProfileMapping()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }

        public void AddDistrictNameProfileMapping()
        {
            CreateMap<District, DistrictDto>()
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.DistrictName));
        }

        public void AddLocationProfileMapping()
        {
            CreateMap<Location, LocationDto>()
                .ForMember(dest => dest.Pleace, opt => opt.MapFrom(src => src.Pleace));
        }

        public void AddRegionProfileMapping()
        {
            CreateMap<Region, RegionDto>()
                .ForMember(dest => dest.RegionName, opt => opt.MapFrom(src => src.RegionName));
        }

        public void AddUserInfoProfileMapping()
        {
            CreateMap<UserInfo, UserInfoDto>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}