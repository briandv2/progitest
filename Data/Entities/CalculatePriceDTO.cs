using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class CalculatePriceDTO
    {
        public double price { get; set; }
        public VehicleType vehicleType { get; set; }
    }
}
