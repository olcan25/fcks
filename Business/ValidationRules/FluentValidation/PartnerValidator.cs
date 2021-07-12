using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PartnerValidator : AbstractValidator<Partner>
    {
        public PartnerValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(250);

            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.Country).MaximumLength(100);

            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.City).MaximumLength(100);

            RuleFor(x => x.UniqueIdentificationNumber).NotEmpty();
            RuleFor(x => x.UniqueIdentificationNumber).Length(9);
            RuleFor(x => x.UniqueIdentificationNumber).Must(x => x.StartsWith('6') || x.StartsWith('8'))
                .WithMessage("UID number starts with 8 or 6");
            

            RuleFor(x => x.VatNumber).Length(9).When(x => !string.IsNullOrWhiteSpace(x.VatNumber));
            RuleFor(x => x.VatNumber).Must(x => x.StartsWith('3')).When(x => !string.IsNullOrEmpty(x.VatNumber));
            RuleFor(x => x.VatNumber).NotEmpty().When(x => x.PartnerTypeId == 1);

            RuleFor(x => x.AdditionalInformation).Length(0, 250).When(x => !string.IsNullOrWhiteSpace(x.AdditionalInformation));

            RuleFor(x => x.Address).MaximumLength(250);

            RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email));
            RuleFor(x => x.Email).Length(5, 50).When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.ContactName).Length(3, 40).When(x => !string.IsNullOrWhiteSpace(x.ContactName));

            RuleFor(x => x.Fax).Length(3, 25).When(x => !string.IsNullOrWhiteSpace(x.Fax));

            RuleFor(x => x.Phone).Length(3, 25).When(x => !string.IsNullOrWhiteSpace(x.Phone));

            RuleFor(x => x.PartnerTypeId).NotEmpty();

            RuleFor(x => x.ZipCode).Length(5).When(x => !string.IsNullOrWhiteSpace(x.ZipCode));

            RuleFor(x => x.Website).Length(5, 100).When(x => !string.IsNullOrWhiteSpace(x.Website));
        }
    }
}
