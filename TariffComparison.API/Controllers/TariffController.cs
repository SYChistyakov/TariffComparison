using TariffComparison.API.DTO;
using TariffComparison.API.Services;
using TariffComparison.Domain;
using Microsoft.AspNetCore.Mvc;

namespace TariffComparison.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class TariffController : ControllerBase
    {
        private readonly TariffService _tariffService;

        public TariffController(TariffService tariffService)
        {
            _tariffService = tariffService;
        }

        [HttpPost("comparison")]
        public ActionResult<ICollection<TariffCalculator>> CompareTariffs([FromBody] int consumption)
        {
            if (consumption < 0)
            {
                return BadRequest("Consumption cannot be negative.");
            }

            var tariffCosts = _tariffService
                .CalculateAnnualCosts(consumption)
                .Select(x => new TariffCostsDTO()
                {
                    TariffName = x.TariffName,
                    AnnualCosts = x.AnnualCosts
                });

            return Ok(tariffCosts);
        }
    }
}
