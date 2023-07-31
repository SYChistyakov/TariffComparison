namespace TariffComparison.Domain
{
    public sealed class TariffCalculatorFactory
    {
        public TariffCalculator CreateCalculator(ExternalTariffData data)
        {
            switch (data.Type)
            {
                case 1:
                    return new BasicElectricityTariffCalculator(data.BaseCost, data.AdditionalKwhCost);
                case 2:
                    return new PackagedTariffCalculator(data.BaseCost, data.IncludedKwh, data.AdditionalKwhCost);
                default:
                    throw new ArgumentException($"Unsupported tariff type {data.Type}", nameof(data));
            }
        }
    }
}
