using Core.Dto;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICalculatePrice
    {
        CalculatePriceResponseDto Calculate(CalculatePriceRequestDto priceRequestDto);
        double CalculateBasicBuyerFee(double price, VehicleType vehicleType);
        double CalculateBasicSellerFee(double price, VehicleType vehicleType);
        double CalculateAssociationPrice(double price);
    }
}