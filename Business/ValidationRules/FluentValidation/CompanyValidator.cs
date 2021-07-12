using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name).MaximumLength(500);
            
            RuleFor(x => x.VatNumber).Length(9).When(x => !string.IsNullOrEmpty(x.VatNumber));
            
            RuleFor(x => x.UniqueIdentificationNumber).NotEmpty().Length(9);
        }
    }
}