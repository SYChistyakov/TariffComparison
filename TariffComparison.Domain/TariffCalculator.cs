namespace TariffComparison.Domain
{
    public abstract class TariffCalculator
    {
        public double CalculateAnnualCosts(int consumption)
        {
            if (consumption < 0)
            {
                throw new ArgumentException("Consumption cannot be less than zero.", nameof(consumption));
            }

            return CalculateAnnualCostsInternal(consumption);
        }

        protected abstract double CalculateAnnualCostsInternal(int consumption);
    }
}