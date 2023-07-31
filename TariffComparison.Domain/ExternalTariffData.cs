namespace TariffComparison.Domain
{
    public sealed class ExternalTariffData
    {
        public required string Name { get; set; }
        public int Type { get; set; }
        public int BaseCost { get; set; }
        public int AdditionalKwhCost { get; set; }
        public int IncludedKwh { get; set; }
    }
}
