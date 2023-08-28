using FluentValidation;

namespace HumanCapital.Extensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> NotNullOrEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> builder, string errorMessage)
        {
            return builder
                .NotNull()
                .WithMessage(errorMessage)
                .NotEmpty() // Doesn't work. TODO: investigate later
                .WithMessage(errorMessage);
        }
    }
}
