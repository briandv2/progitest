using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class CalculatePriceRequestDto
    {
        public double price { get; set; }
        public VehicleType vehicleType { get; set; }
    }
}
