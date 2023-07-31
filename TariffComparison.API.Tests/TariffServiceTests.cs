using TariffComparison.API.Services;
using TariffComparison.Domain;
using Moq;

namespace TariffComparison.API.Tests
{
    public class TariffServiceTests
    {
        [Fact]
        public void CalculateAnnualCosts_ReturnsCorrectResults()
        {
            // Arrange
            var tariffData = new List<ExternalTariffData>
            {
                new ExternalTariffData { Name = "Product A", Type = 1, BaseCost = 5, AdditionalKwhCost = 22 },
                new ExternalTariffData { Name = "Product B", Type = 2, IncludedKwh = 4000, BaseCost = 800, AdditionalKwhCost = 30 },
            };

            var mockProvider = new Mock<IExternalTariffProvider>();
            mockProvider.Setup(p => p.GetTariffsData()).Returns(tariffData);

            var factory = new TariffCalculatorFactory();

            var service = new TariffService(mockProvider.Object, factory);

            // Act
            var results = service.CalculateAnnualCosts(4500);

            // Assert
            Assert.Equal(2, results.Count);
            Assert.Equal(("Product A", 1050), results.ElementAt(0));
            Assert.Equal(("Product B", 950), results.ElementAt(1));
        }
    }
}