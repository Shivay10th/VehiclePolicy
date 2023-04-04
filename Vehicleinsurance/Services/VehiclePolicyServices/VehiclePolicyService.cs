using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicleinsurance.DTOs.VehiclePolicyDtos;
using VehicleInsurance_81380.Models;

namespace Vehicleinsurance.Services.VehiclePolicyServices
{
    class VehiclePolicyService : IVehiclePolicyService
    {
        private readonly VI_81380Context _dbContext;


        public VehiclePolicyService(VI_81380Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VehiclePolicyGetDto> DeleteVehiclePolicy(int vehiclePolicyId)
        {
            var policy = await _dbContext.VehiclePolicy.Where(vp => vp.PolicyId == vehiclePolicyId).FirstOrDefaultAsync();
            if (policy==null)
            {
                return null;
            }
            _dbContext.Remove(policy);
            _dbContext.SaveChanges();
            var res = new VehiclePolicyGetDto()
            {
                PolicyId=policy.PolicyId,
                CompanyId=policy.CompanyId,
                IDV=policy.IDV,
                PolicyEndDate=policy.PolicyEndDate,
                PolicyName=policy.PolicyName,
                PolicyRegistrationDate=policy.PolicyRegistrationDate,
                TotalPayableAmt=policy.TotalPayableAmt
            };
            return res;
        }

        public async Task<List<VehiclePolicyGetDto>> GetVehicalePolicies()
        {
            var vehiclePolicies =await _dbContext.VehiclePolicy.ToListAsync();
            List<VehiclePolicyGetDto> vehicalPolicyDto = new List<VehiclePolicyGetDto>();
            foreach (var item in vehiclePolicies)
            {
                vehicalPolicyDto.Add(new VehiclePolicyGetDto()
                {
                    CompanyId = item.CompanyId,
                    IDV=item.IDV,
                    PolicyEndDate=item.PolicyEndDate,
                    PolicyRegistrationDate=item.PolicyRegistrationDate,
                    PolicyId=item.PolicyId,
                    PolicyName=item.PolicyName,
                    TotalPayableAmt=item.TotalPayableAmt
                });
            }
            return vehicalPolicyDto;
        }



        public async Task<VehiclePolicyGetDto> PostVehicalPolicy(VehiclePolicyPostDto vehiclePolicyPostDto)
        {
            var newVehiclePolicy = new VehiclePolicy {
                CompanyId=vehiclePolicyPostDto.CompanyId,
                PolicyName=vehiclePolicyPostDto.PolicyName,
                IDV=vehiclePolicyPostDto.IDV,
                TotalPayableAmt=vehiclePolicyPostDto.TotalPayableAmt,
                PolicyRegistrationDate=DateTime.Now,
                PolicyEndDate=vehiclePolicyPostDto.PolicyEndDate,
            };
            var vp =await _dbContext.VehiclePolicy.AddAsync(newVehiclePolicy);
            await _dbContext.SaveChangesAsync();
            var returnvp = new VehiclePolicyGetDto {
                PolicyId=vp.Entity.PolicyId,
            };
            return returnvp;

            
        }
    }
}
