using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicleinsurance.DTOs.VehicleDtos;
using Vehicleinsurance.Services.VehicleServices;

namespace Vehicleinsurance.Controllers
{
    [Route("/api/vehicle")]
    [ApiController]
    public class VehicleController:ControllerBase
    {
        private readonly IVehicleService _vehicleSRV;

        public VehicleController(IVehicleService vehicleSRV)
        {
            _vehicleSRV = vehicleSRV;
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<VehicleGetDto>>> GetVehiclesByUserId(int userId)
        {
            //get user by id and check if user exist or not
            var vehicleList = await _vehicleSRV.GetVehicleByUserId(userId);
            return Ok(vehicleList);
        }
    }
}
