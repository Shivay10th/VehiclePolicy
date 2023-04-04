using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicleinsurance.DTOs.VehicleDtos;
using VehicleInsurance_81380.Models;

namespace Vehicleinsurance.Services.VehicleServices
{
    public class VehicleService : IVehicleService
    {
        private readonly VI_81380Context _dbcontext;

        public VehicleService(VI_81380Context context)
        {
            _dbcontext = context;
        }

        public async Task<IEnumerable<VehicleGetDto>> GetVehicleByUserId(int userId)
        {

            var vehicles =await _dbcontext.Vehicle.Where(c => c.OwnerId == userId).ToListAsync();
            var vehicleDtos = new List<VehicleGetDto>();
            foreach (var vehicle in vehicles)
            {
                vehicleDtos.Add(new VehicleGetDto()
                {
                    OwnerId = vehicle.OwnerId,
                    VehicleChassisNo = vehicle.VehicleChassisNo,
                    VehicleColor = vehicle.VehicleColor,
                    VehicleId = vehicle.VehicleId,
                    VehicleModel = vehicle.VehicleModel,
                    VehicleRegistraionDate = vehicle.VehicleRegistraionDate,
                    VehicleRegistrationNo = vehicle.VehicleRegistrationNo,
                    VehicleType = vehicle.VehicleType
                });
            }
            return vehicleDtos;
        }
        public async Task<VehicleGetDto> CreateVehicle(int ownerId,VehiclePostDto vehicle)
        {
            return new VehicleGetDto();
        }
    }
}
