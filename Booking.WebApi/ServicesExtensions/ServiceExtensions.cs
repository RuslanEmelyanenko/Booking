using AutoMapper;
using Booking.Repository.Abstractions;
using Booking.Repository.Implementations;
using Booking.Services.Abstraction;
using Booking.Services.Implementation;
using Booking.WebApi.MappingProfiles;

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

            return services;
        }

        public static IServiceCollection ConfigureRepositorices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IApartmentRepository, ApartmentRepository>();

            return services;
        }
    }
}