using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {
        public CurrencyValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.ShortName).NotEmpty();
            RuleFor(x => x.ShortName).MaximumLength(3);

            RuleFor(x => x.Symbol).NotEmpty();
            RuleFor(x => x.Symbol).MaximumLength(3);
        }
    }
}
