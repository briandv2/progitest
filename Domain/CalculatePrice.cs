using Common;
using Data.Entities;
using Domain.interfaces;
using Microsoft.Extensions.Options;

namespace Domain
{
    public class CalculatePrice : ICalculePrice
    {

        private readonly FeeSettings _feeSettings;
        public CalculatePrice (IOptions<FeeSettings> feeSettings)
        {
            _feeSettings = feeSettings.Value;
        }

        public CalculatePriceResponseDTO calculate(double price, VehicleType vehicleType)
        {
            var response = new CalculatePriceResponseDTO();
            response.basic = calculateBasicBuyerFee(price, vehicleType);
            response.special = calculateBasicSellerFee(price, vehicleType);
            response.association = associationPrice(price);
            response.storage = _feeSettings.FixedFee;
            response.total = price + response.basic + response.special + response.association + response.storage;
            return response;
        }

        public double calculateBasicBuyerFee(double price, VehicleType vehicleType)
        {
            var minValue = vehicleType == VehicleType.Common ? _feeSettings.CommonBuyerFeeMinValue : _feeSettings.LuxuryBuyerFeeMinValue;
            var maxValue = vehicleType == VehicleType.Common ? _feeSettings.CommonBuyerFeeMaxValue : _feeSettings.LuxuryBuyerFeeMaxValue;
            var fee = price * _feeSettings.BuyerFeePercent;
            if (fee < minValue)
                return minValue;
            else if (fee > maxValue)
                return maxValue;
            return fee;
        }

        public double calculateBasicSellerFee(double price, VehicleType vehicleType)
        {
            var percent = vehicleType == VehicleType.Common ? _feeSettings.CommonSellerFeePercent : _feeSettings.LuxurySellerFeePercent;
            return price * percent;
        }

        public double associationPrice(double price)
        {
            double associationPrice = 0;
            if (price is > 1 and < 500)
                associationPrice = _feeSettings.Association1And500;
            else if (price is > 500 and < 1000)
                associationPrice = _feeSettings.Association500And1000;
            else if (price is > 1000 and < 3000)
                associationPrice = _feeSettings.Association1000And3000;
            else if (price is > 3000)
                associationPrice = _feeSettings.AssociationOver3000;
            return associationPrice;
        }

    }
}
