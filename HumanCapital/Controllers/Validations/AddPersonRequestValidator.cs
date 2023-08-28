using FluentValidation;
using HumanCapital.Extensions;
using HumanCapital.Models;

namespace HumanCapital.Controllers.Validations
{
    public class AddPersonRequestValidator : AbstractValidator<AddPersonRequest>
    {
        public AddPersonRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNullOrEmpty("FirstName is empty");

            RuleFor(x => x.LastName)
                .NotNullOrEmpty("LastName is empty");

            RuleFor(x => x.Salary)
                .GreaterThan(1) //This validation doesn't work! TODO: investigate further
                //.Must(s => s > 0) //DOesn't work also
                .WithMessage("Salary must be positive number");
                

            RuleFor(x => x.Department)
                .NotNullOrEmpty("Department is empty");
        }
    }
}
