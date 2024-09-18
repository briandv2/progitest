using Common;
using Data.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface ICalculePrice
    {
        CalculatePriceResponseDTO calculate(double price, VehicleType vehicleType);
    }
}
