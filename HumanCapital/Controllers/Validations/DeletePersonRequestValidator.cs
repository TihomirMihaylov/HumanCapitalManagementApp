using FluentValidation;
using HumanCapital.Models;

namespace HumanCapital.Controllers.Validations
{
    public class DeletePersonRequestValidator : AbstractValidator<DeletePersonRequest>
    {
        public DeletePersonRequestValidator()
        {
            RuleFor(x => x.PersonId) // Doesn't work. TODO: investigate later
                .GreaterThan(default(int))
                .WithMessage("PersonId is invalid");
        }
    }
}
