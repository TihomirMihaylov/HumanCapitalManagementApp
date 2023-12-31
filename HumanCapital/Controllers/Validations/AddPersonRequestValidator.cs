﻿using FluentValidation;
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
                .GreaterThan(1) // Doesn't work. TODO: investigate later
                 //.Must(s => s > 0) //Doesn't work either
                .WithMessage("Salary must be positive number");
                

            RuleFor(x => x.Department)
                .NotNullOrEmpty("Department is empty");
        }
    }
}
