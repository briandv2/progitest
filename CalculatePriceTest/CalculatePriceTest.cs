using Application.Services;
using Core.Dto;
using Core.Entities;
using Core.Interfaces;
using Xunit;

public class CalculatePriceServiceTests
{
    private readonly ICalculatePrice _calculatePriceService;

    public CalculatePriceServiceTests()
    {
        _calculatePriceService = new CalculatePriceService();
    }

    [Fact]
    public void Calculate_ShouldReturnCorrectTotal_ForCommonVehicle()
    {
        // Arrange
        var request = new CalculatePriceRequestDto
        {
            price = 1000,
            vehicleType = VehicleType.Common
        };

        // Act
        var result = _calculatePriceService.Calculate(request);

        // Assert
        Assert.Equal(50, result.Basic);
        Assert.Equal(20, result.Special);
        Assert.Equal(15, result.Association);
        Assert.Equal(1185, result.Total);
    }

    [Fact]
    public void Calculate_ShouldReturnCorrectTotal_ForLuxuryVehicle()
    {
        // Arrange
        var request = new CalculatePriceRequestDto
        {
            price = 1000,
            vehicleType = VehicleType.Luxury
        };

        // Act
        var result = _calculatePriceService.Calculate(request);

        // Assert
        Assert.Equal(100, result.Basic);
        Assert.Equal(40, result.Special);
        Assert.Equal(15, result.Association);
        Assert.Equal(1255, result.Total);
    }

    [Fact]
    public void CalculateBasicBuyerFee_ShouldReturnMinValue_ForLowPriceCommonVehicle()
    {
        // Arrange
        var price = 50;
        var vehicleType = VehicleType.Common;

        // Act
        var result = _calculatePriceService.CalculateBasicBuyerFee(price, vehicleType);

        // Assert
        Assert.Equal(10, result);
    }

    [Fact]
    public void CalculateBasicBuyerFee_ShouldReturnMaxValue_ForHighPriceLuxuryVehicle()
    {
        // Arrange
        var price = 3000;
        var vehicleType = VehicleType.Luxury;

        // Act
        var result = _calculatePriceService.CalculateBasicBuyerFee(price, vehicleType);

        // Assert
        Assert.Equal(200, result);
    }

    [Fact]
    public void CalculateBasicSellerFee_ShouldReturnCorrectValue_ForCommonVehicle()
    {
        // Arrange
        var price = 1000;
        var vehicleType = VehicleType.Common;

        // Act
        var result = _calculatePriceService.CalculateBasicSellerFee(price, vehicleType);

        // Assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void AssociationPrice_ShouldReturnCorrectValue_ForPriceRange()
    {
        // Arrange
        var price = 1500;

        // Act
        var result = _calculatePriceService.CalculateAssociationPrice(price);

        // Assert
        Assert.Equal(15, result);
    }
}