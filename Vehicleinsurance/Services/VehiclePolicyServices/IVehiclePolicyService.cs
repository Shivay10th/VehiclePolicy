using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicleinsurance.DTOs.VehiclePolicyDtos;

namespace Vehicleinsurance.Services.VehiclePolicyServices
{
    public interface IVehiclePolicyService
    {
        Task<List<VehiclePolicyGetDto>> GetVehicalePolicies();
        Task<VehiclePolicyGetDto> PostVehicalPolicy(VehiclePolicyPostDto vehiclePolicyPostDto);
        Task<VehiclePolicyGetDto> DeleteVehiclePolicy(int VehiclePolicyId);
    }
}
