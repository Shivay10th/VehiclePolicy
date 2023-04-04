using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicleinsurance.DTOs.VehicleDtos;

namespace Vehicleinsurance.Services.VehicleServices
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleGetDto>> GetVehicleByUserId(int userId);
        Task<VehicleGetDto> CreateVehicle(int ownerId, VehiclePostDto vehicle);
    }
}
