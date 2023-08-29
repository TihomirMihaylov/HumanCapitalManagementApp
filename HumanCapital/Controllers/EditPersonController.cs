using HumanCapital.Exceptions;
using HumanCapital.Models;
using HumanCapital.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanCapital.Controllers
{
    [ApiController]
    [Route("editPerson")]
    public class EditPersonController : PersonBaseController
    {
        public EditPersonController(IPersonService personService)
            : base(personService) { }

        //TODO: restrict endpoint to logged in user with admin role
        public async Task<BaseResponse> Post(Person request)
        {
            TotalHttpRequestCounter.Inc();

            try
            {
                var result = await _personService.EditPersonAsync(request, Cts.Token);

                return new BaseResponse
                {
                    Person = result
                };
            }
            catch (PersonNotFoundException notFoundEx)
            {
                return new BaseResponse
                {
                    Error = notFoundEx.Message
                };
            }
        }
    }
}
