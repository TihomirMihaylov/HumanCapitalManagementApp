using HumanCapital.Models;
using HumanCapital.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanCapital.Controllers
{
    [ApiController]
    [Route("addPerson")]
    public class AddPersonController : PersonBaseController
    {
        public AddPersonController(IPersonService personService)
            : base(personService) { }

        //TODO: restrict endpoint to logged in user with admin role
        public async Task<Person> Post(AddPersonRequest request)
            => await _personService.AddPersonAsync(request, Cts.Token);
    }
}
