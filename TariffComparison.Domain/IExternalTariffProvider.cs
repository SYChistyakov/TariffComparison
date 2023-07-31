namespace TariffComparison.Domain
{
    public interface IExternalTariffProvider
    {
        IEnumerable<ExternalTariffData> GetTariffsData();
    }
}