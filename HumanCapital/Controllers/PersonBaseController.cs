using HumanCapital.Services;
using Prometheus;

namespace HumanCapital.Controllers
{
    public abstract class PersonBaseController : ApiBaseController
    {
        protected readonly IPersonService _personService;
        protected static readonly Counter TotalHttpRequestCounter = Metrics.CreateCounter("http_requests_total", "Total HTTP Requests");
        public PersonBaseController(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }
    }
}
