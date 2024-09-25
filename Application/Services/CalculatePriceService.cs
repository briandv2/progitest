using Core.Dto;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class CalculatePriceService : ICalculatePrice
    {
        private const double CommonMinBuyerFee = 10;
        private const double LuxuryMinBuyerFee = 25;
        private const double CommonMaxBuyerFee = 50;
        private const double LuxuryMaxBuyerFee = 200;
        private const double CommonSellerFeePercent = 0.02;
        private const double LuxurySellerFeePercent = 0.04;
        private const double FixedFee = 100;

        public CalculatePriceService()
        {
        }

        public CalculatePriceResponseDto Calculate(CalculatePriceRequestDto priceRequestDto)
        {
            ValidateRequest(priceRequestDto);

            var calculatePriceResponseDto = new CalculatePriceResponseDto
            {
                Basic = CalculateBasicBuyerFee(priceRequestDto.price, priceRequestDto.vehicleType),
                Special = CalculateBasicSellerFee(priceRequestDto.price, priceRequestDto.vehicleType),
                Association = CalculateAssociationPrice(priceRequestDto.price),
            };
            calculatePriceResponseDto.Total = CalculateTotalPrice(priceRequestDto.price, calculatePriceResponseDto);
            return calculatePriceResponseDto;
        }

        public void ValidateRequest(CalculatePriceRequestDto priceRequestDto)
        {
            if (priceRequestDto.price <= 0)
                throw new ArgumentException("Price must be greater than zero.");
        }

        public double CalculateBasicBuyerFee(double price, VehicleType vehicleType)
        {
            var minValue = vehicleType == VehicleType.Common ? CommonMinBuyerFee : LuxuryMinBuyerFee;
            var maxValue = vehicleType == VehicleType.Common ? CommonMaxBuyerFee : LuxuryMaxBuyerFee;
            var fee = price * 0.1;

            if (fee < minValue)
                return minValue;
            else if (fee > maxValue)
                return maxValue;

            return fee;
        }

        public double CalculateBasicSellerFee(double price, VehicleType vehicleType)
        {
            var percent = vehicleType == VehicleType.Common ? CommonSellerFeePercent : LuxurySellerFeePercent;
            return price * percent;
        }

        public double CalculateAssociationPrice(double price)
        {
            return price switch
            {
                > 1 and < 500 => 5,
                > 500 and < 1000 => 10,
                > 1000 and < 3000 => 15,
                > 3000 => 20,
                _ => 0
            };
        }

        public double CalculateTotalPrice(double price, CalculatePriceResponseDto responseDto)
        {
            return price + responseDto.Basic + responseDto.Special + responseDto.Association + FixedFee;
        }


    }
}