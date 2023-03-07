using FluentValidation;
using MinimalAPI.Models;

namespace MinimalAPI.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MinimumLength(2);
        }
    }
}
