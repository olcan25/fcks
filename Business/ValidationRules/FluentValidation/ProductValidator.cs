using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.UnitOfMeasureId).NotEmpty();

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(3, 250);

            RuleFor(x => x.VatId).NotEmpty().WithMessage("Vat Rate Not Empty");

            RuleFor(x => x.ProductTypeId).NotEmpty().WithMessage("Product Type Not Empty");

            RuleFor(x => x.UnitOfMeasureId).NotEmpty().WithMessage("Unit Of Measure Not Empty");

            //RuleForEach(x => x.ProductBarcodes).SetValidator(new ProductBarcodeValidator());
        }
    }
}
