using HumanCapital.Exceptions;
using HumanCapital.Models;
using HumanCapital.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanCapital.Controllers
{
    [ApiController]
    [Route("deletePerson")]
    public class DeletePersonController : PersonBaseController
    {
        public DeletePersonController(IPersonService personService)
            : base(personService) { }

        //TODO: restrict endpoint to logged in user with admin role
        public async Task<BaseResponse> Post(DeletePersonRequest request)
        {
            TotalHttpRequestCounter.Inc();

            try
            {
                await _personService.DeletePersonAsync(request.PersonId, Cts.Token);

                return new BaseResponse();
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
