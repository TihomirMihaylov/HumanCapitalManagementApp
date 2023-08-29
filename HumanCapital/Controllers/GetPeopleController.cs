using HumanCapital.Models;
using HumanCapital.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanCapital.Controllers
{
    [ApiController]
    [Route("people")]
    public class GetPeopleController : PersonBaseController
    {
        public GetPeopleController(IPersonService personService)
            : base(personService) { }

        //TODO: restrict endpoint to logged in users
        public async Task<IEnumerable<Person>> Get()
        {
            TotalHttpRequestCounter.Inc();
            
            return await _personService.GetAllPeopleAsync(Cts.Token);
        }
    }
}
