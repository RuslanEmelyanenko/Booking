using AutoMapper;
using Booking.Models;
using Booking.Repository.Abstractions;
using Booking.Repository.Implementations;
using Booking.Services.Abstraction;
using Booking.Services.Implementation;
using Booking.WebApi.MappingProfiles;
using Microsoft.EntityFrameworkCore;

namespace Booking.WebApi.ServicesExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {

            services.AddTransient<IApartmentService, ApartmentService>();
            services.AddTransient<IBookingConfirmationService, BookingConfirmationService>(); 
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IDistrictService, DistrictService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IRegionService, RegionService>();

            return services;
        }

        public static IServiceCollection ConfigureRepositorices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IApartmentRepository, ApartmentRepository>();
            services.AddTransient<IBookingConfirmationsRepository, BookingConfirmationsRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IDistrictRepository, DistrictRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();

            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString:BookingDB").Value;
            services.AddDbContext<BookingDBContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}