using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Dtos.BaseDTOs;

namespace Booking.Services.Abstraction
{
    public interface IApartmentService
    {
        Task<IList<ApartmentDto>> GatAllAsync();
    }
}