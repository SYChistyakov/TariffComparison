namespace TariffComparison.Domain
{

    public sealed class BasicElectricityTariffCalculator : TariffCalculator
    {
        private readonly int _baseCostPerMonth;
        private readonly int _costPerKwh;

        public BasicElectricityTariffCalculator(int baseCostPerMonth, int costPerKwh)
        {
            _baseCostPerMonth = baseCostPerMonth;
            _costPerKwh = costPerKwh;
        }

        protected override double CalculateAnnualCostsInternal(int consumption)
        {
            return _baseCostPerMonth * 12 + (_costPerKwh * consumption / 100.0d);
        }
    }
}