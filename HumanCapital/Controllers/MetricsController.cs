using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace HumanCapital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetricsController : ApiBaseController
    {
        [HttpGet]
        [Route("metrics")]
        public IActionResult GetMetrics()
        {
            return Ok(Metrics.DefaultRegistry.CollectAndExportAsTextAsync(Stream.Null, Cts.Token));
        }
    }
}
