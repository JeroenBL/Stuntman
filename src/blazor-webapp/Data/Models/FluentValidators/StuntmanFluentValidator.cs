using FluentValidation;

namespace Stuntman.Web.Data.Models.FluentValidators
{
    public class StuntmanFluentValidator : AbstractValidator<StuntmanModel>
    {
        public StuntmanFluentValidator()
        {
            RuleFor(s => s.BusinessEmailAddress)
                .NotEmpty();

            RuleFor(s => s.Company)
                .NotEmpty();
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<StuntmanModel>.CreateWithOptions((StuntmanModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
