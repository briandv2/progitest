namespace Core.Dto
{
    public class CalculatePriceResponseDto
    {
        public double Basic { get; set; } = 0.0;
        public double Special { get; set; } = 0.0;
        public double Association { get; set; } = 0.0;
        public double Storage { get; set; } = 100;
        public double Total { get; set; } = 0.0;
    }
}