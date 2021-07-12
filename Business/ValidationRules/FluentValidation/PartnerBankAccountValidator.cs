using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PartnerBankAccountValidator : AbstractValidator<PartnerBankAccount>
    {
        public PartnerBankAccountValidator()
        {
            RuleFor(x => x.PartnerId).NotEmpty();

            RuleFor(x => x.BankId).NotEmpty();

            RuleFor(x => x.AccountNumber).NotEmpty();
            RuleFor(x => x.AccountNumber).Length(10, 18);

            RuleFor(x => x.SwiftCode).MaximumLength(10).When(x => !string.IsNullOrWhiteSpace(x.SwiftCode));

            RuleFor(x => x.Iban).MaximumLength(12).When(x => !string.IsNullOrWhiteSpace(x.Iban));
        }
    }
}
