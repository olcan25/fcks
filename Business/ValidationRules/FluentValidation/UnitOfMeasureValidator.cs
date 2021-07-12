using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UnitOfMeasureValidator : AbstractValidator<UnitOfMeasure>
    {
        public UnitOfMeasureValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(40);

            RuleFor(x => x.ShortName).NotEmpty();
            RuleFor(x => x.ShortName).MaximumLength(4);
        }
    }
}