using FluentValidation;
using HumanCapital.Extensions;
using HumanCapital.Models;

namespace HumanCapital.Controllers.Validations
{
    public class EditPersonValidator : AbstractValidator<Person>
    {
        public EditPersonValidator()
        {
            RuleFor(x => x.Id) // Doesn't work. TODO: investigate later
                .GreaterThan(default(int))
                .WithMessage("Id is invalid");

            RuleFor(x => x.FirstName)
                .NotNullOrEmpty("FirstName is empty");

            RuleFor(x => x.LastName)
                .NotNullOrEmpty("LastName is empty");

            RuleFor(x => x.Salary)
                .GreaterThan(default(decimal)) // Doesn't work. TODO: investigate later
                .WithMessage("Salary must be positive number");

            RuleFor(x => x.Department)
                .NotNullOrEmpty("Department is empty");
        }
    }
}
