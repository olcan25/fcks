using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyBankAccountValidator : AbstractValidator<CompanyBankAccount>
    {
        public CompanyBankAccountValidator()
        {
            RuleFor(x => x.BankId).NotEmpty().WithMessage("Bank Name Not Empty");

            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Company Name Not Empty");

            RuleFor(x => x.AccountNumber).NotEmpty();
            RuleFor(x => x.AccountNumber).Length(12,25);

            RuleFor(x => x.Iban).Length(0, 8);

            RuleFor(x => x.SwiftCode).Length(0, 12);
        }
    }
}
