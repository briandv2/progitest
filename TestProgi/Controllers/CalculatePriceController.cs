using Data.Entities;
using Domain.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProgi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatePriceController : Controller
    {
        ICalculePrice _calculePrice;
        public CalculatePriceController(ICalculePrice calculePrice)
        {
            _calculePrice = calculePrice;
        }

        [HttpPost("Post")]
        public IActionResult Post(CalculatePriceDTO calculatePriceDTO)
        {
           var price = _calculePrice.calculate(calculatePriceDTO.price, calculatePriceDTO.vehicleType); 
            return Ok(price);
        }
    }
}
