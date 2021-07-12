using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WarehouseValidator : AbstractValidator<Warehouse>
    {
        public WarehouseValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(40);

            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.City).NotEmpty();

            //RuleFor(x => x.ZipCode).Length(5).When(x => !string.IsNullOrEmpty(x.ZipCode));
            RuleFor(x => x.ZipCode).Length(5);

            RuleFor(x => x.AddressDetail).NotEmpty();
            RuleFor(x => x.AddressDetail).MaximumLength(250);

            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Sirket Ismi Bos Olamaz..");
        }
    }
}
