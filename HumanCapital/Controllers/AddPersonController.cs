using HumanCapital.Models;
using HumanCapital.Services;
using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace HumanCapital.Controllers
{
    [ApiController]
    [Route("addPerson")]
    public class AddPersonController : PersonBaseController
    {
        private readonly Counter _counter;

        public AddPersonController(IPersonService personService)
            : base(personService)
        {
            _counter = Metrics.CreateCounter("http_requests_add_person_total", "Total Add Person HTTP Requests");
        }

        //TODO: restrict endpoint to logged in user with admin role
        public async Task<Person> Post(AddPersonRequest request)
        {
            TotalHttpRequestCounter.Inc();
            _counter.Inc();

            return await _personService.AddPersonAsync(request, Cts.Token);
        }
    }
}
