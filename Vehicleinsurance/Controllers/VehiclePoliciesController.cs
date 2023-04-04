using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicleinsurance.DTOs.VehiclePolicyDtos;
using Vehicleinsurance.Services.VehiclePolicyServices;
using VehicleInsurance_81380.Models;

namespace Vehicleinsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclePoliciesController : ControllerBase
    {
        private readonly VI_81380Context _context;
        private readonly IVehiclePolicyService _vehiclePolicyService;

        public VehiclePoliciesController(VI_81380Context context,IVehiclePolicyService vehiclePolicyService)
        {
            _context = context;
            _vehiclePolicyService = vehiclePolicyService;
        }

        // GET: api/VehiclePolicies
        [HttpGet]
        public async Task<IEnumerable<VehiclePolicyGetDto>> GetVehiclePolicy()
        {
            return await _vehiclePolicyService.GetVehicalePolicies();
        }

        // GET: api/VehiclePolicies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehiclePolicy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehiclePolicy = await _context.VehiclePolicy.FindAsync(id);

            if (vehiclePolicy == null)
            {
                return NotFound();
            }

            return Ok(vehiclePolicy);
        }

        // PUT: api/VehiclePolicies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiclePolicy([FromRoute] int id, [FromBody] VehiclePolicy vehiclePolicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehiclePolicy.PolicyId)
            {
                return BadRequest();
            }

            _context.Entry(vehiclePolicy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiclePolicyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VehiclePolicies
        [HttpPost]
        public async Task<IActionResult> PostVehiclePolicy([FromBody] VehiclePolicyPostDto vehiclePolicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _vehiclePolicyService.PostVehicalPolicy(vehiclePolicy);

            return CreatedAtAction("GetVehiclePolicy", new { id = created.PolicyId }, created);
        }

        // DELETE: api/VehiclePolicies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiclePolicy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehiclePolicy = await _vehiclePolicyService.DeleteVehiclePolicy(id);
            if (vehiclePolicy == null)
            {
                return NotFound();
            }

            return Ok(vehiclePolicy);
        }

        private bool VehiclePolicyExists(int id)
        {
            return _context.VehiclePolicy.Any(e => e.PolicyId == id);
        }
    }
}