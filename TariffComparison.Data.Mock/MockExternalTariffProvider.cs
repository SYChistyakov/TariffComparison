using TariffComparison.Domain;

namespace TariffComparison.Data.Mock
{
    public class MockExternalTariffProvider : IExternalTariffProvider
    {
        public IEnumerable<ExternalTariffData> GetTariffsData()
        {
            return new List<ExternalTariffData>
            {
                new ExternalTariffData { Name = "Product A", Type = 1, BaseCost = 5, AdditionalKwhCost = 22 },
                new ExternalTariffData { Name = "Product B", Type = 2, IncludedKwh = 4000, BaseCost = 800, AdditionalKwhCost = 30 },
            };
        }
    }
}