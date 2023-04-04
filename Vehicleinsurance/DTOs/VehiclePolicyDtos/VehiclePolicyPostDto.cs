using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicleinsurance.DTOs.VehiclePolicyDtos
{
    public class VehiclePolicyPostDto
    {
        public int? CompanyId { get; set; }
        public string PolicyName { get; set; }
        public decimal? TotalPayableAmt { get; set; }
        public decimal? IDV { get; set; }
        public DateTime PolicyEndDate { get; set; }
    }
}
