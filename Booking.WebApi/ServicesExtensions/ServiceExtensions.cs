using AutoMapper;
using Booking.WebApi.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped((Type)mapper);

            return services;
        }
    }
}