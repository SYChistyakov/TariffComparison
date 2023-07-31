namespace TariffComparison.Domain.Tests
{
    public class TariffTests
    {
        [Fact]
        public void CalculateAnnualCosts_NegativeConsumption_ThrowsArgumentException()
        {
            // Arrange
            var tariff = new BasicElectricityTariffCalculator(5, 22);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => tariff.CalculateAnnualCosts(-1));
        }


        [Theory]
        [InlineData(3500, 830)]
        [InlineData(4500, 1050)]
        public void BasicElectricityTariff_CalculateAnnualCosts_ReturnsCorrectCost(int consumption, double expected)
        {
            // Arrange
            var tariff = new BasicElectricityTariffCalculator(5, 22);

            // Act
            var result = tariff.CalculateAnnualCosts(consumption);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3500, 800)]
        [InlineData(4500, 950)]
        public void PackagedTariff_CalculateAnnualCosts_ReturnsCorrectCost(int consumption, double expected)
        {
            // Arrange
            var tariff = new PackagedTariffCalculator(800, 4000, 30);

            // Act
            var result = tariff.CalculateAnnualCosts(consumption);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}