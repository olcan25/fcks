using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BankValidator : AbstractValidator<Bank>
    {
        public BankValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3);

            RuleFor(x => x.ShortName).NotEmpty();
            RuleFor(x => x.ShortName).MaximumLength(9);
        }
    }
}