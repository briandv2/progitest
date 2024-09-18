namespace Data.Entities
{
    public class CalculatePriceResponseDTO
    {
        public double basic { get; set; }
        public double special { get; set; }
        public double association { get; set; }
        public double storage { get; set; }
        public double total { get; set; }
    }
}
