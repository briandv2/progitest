using Core.Dto;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatePriceController : ControllerBase
    {
        private readonly ICalculatePrice _calculatePriceService;

        public CalculatePriceController(ICalculatePrice calculatePriceService)
        {
            _calculatePriceService = calculatePriceService;
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] CalculatePriceRequestDto priceRequestDto)
        {
            var priceResponse = _calculatePriceService.Calculate(priceRequestDto);
            return Ok(priceResponse);
        }
    }
}