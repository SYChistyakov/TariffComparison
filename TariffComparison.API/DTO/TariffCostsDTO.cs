namespace TariffComparison.API.DTO
{
    public sealed class TariffCostsDTO
    {
        public required string TariffName { get; set; }
        public double AnnualCosts { get; set; }
    }
}
