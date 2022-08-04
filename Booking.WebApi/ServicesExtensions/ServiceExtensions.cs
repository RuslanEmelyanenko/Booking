using AutoMapper;
using Booking.Models;
using Booking.Repository.Abstractions;
using Booking.Repository.Implementations;
using Booking.Services.Abstraction;
using Booking.Services.Implementation;
using Booking.WebApi.MappingProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.WebApi.ServicesExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IApartmentService, ApartmentService>();

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IApartmentRepository, ApartmentRepository>();

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