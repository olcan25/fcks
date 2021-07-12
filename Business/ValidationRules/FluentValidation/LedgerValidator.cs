using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LedgerValidator : AbstractValidator<Ledger>
    {
        public LedgerValidator()
        {
            RuleFor(x => x.RegisterDate).NotEmpty();
        }
    }
}
