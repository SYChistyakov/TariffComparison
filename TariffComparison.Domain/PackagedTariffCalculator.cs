namespace TariffComparison.Domain
{
    public sealed class PackagedTariffCalculator : TariffCalculator
    {
        private readonly int _baseCost;
        private readonly int _includedKwh;
        private readonly int _costPerAdditionalKwh;

        public PackagedTariffCalculator(int baseCost, int includedKwh, int costPerAdditionalKwh)
        {
            _baseCost = baseCost;
            _includedKwh = includedKwh;
            _costPerAdditionalKwh = costPerAdditionalKwh;
        }

        protected override double CalculateAnnualCostsInternal(int consumption)
        {
            if (consumption <= _includedKwh)
            {
                return _baseCost;
            }
            else
            {
                int additionalConsumption = consumption - _includedKwh;
                return Math.Round(_baseCost + additionalConsumption * _costPerAdditionalKwh / 100.0d, 2);
            }
        }
    }
}