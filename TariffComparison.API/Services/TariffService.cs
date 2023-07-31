using TariffComparison.Domain;

namespace TariffComparison.API.Services
{
    public sealed class TariffService
    {
        private readonly IExternalTariffProvider _externalTariffProvider;
        private readonly TariffCalculatorFactory _tariffCalculatorFactory;

        public TariffService(IExternalTariffProvider externalTariffProvider,
            TariffCalculatorFactory tariffCalculatorFactory)
        {
            _externalTariffProvider = externalTariffProvider;
            _tariffCalculatorFactory = tariffCalculatorFactory;
        }

        public ICollection<(string TariffName, double AnnualCosts)> CalculateAnnualCosts(int consumption)
        {
            var tariffDataList = _externalTariffProvider.GetTariffsData();
            var result = new List<(string TariffName, double AnnualCosts)>();

            foreach (var tariffData in tariffDataList)
            {
                var calculator = _tariffCalculatorFactory.CreateCalculator(tariffData);
                var annualCosts = calculator.CalculateAnnualCosts(consumption);
                result.Add((tariffData.Name, annualCosts));
            }

            return result;
        }
    }
}
