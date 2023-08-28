using HumanCapital.Services;

namespace HumanCapital.Controllers
{
    public abstract class PersonBaseController : ApiBaseController
    {
        protected readonly IPersonService _personService;

        public PersonBaseController(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }
    }
}
