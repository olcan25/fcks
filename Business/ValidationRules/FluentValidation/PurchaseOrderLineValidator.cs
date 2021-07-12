using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PurchaseOrderLineValidator : AbstractValidator<PurchaseOrderLine>
    {
        public PurchaseOrderLineValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();

            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product Name Not Empty");

            RuleFor(x => x.Quantity).NotEmpty();

            RuleFor(x => x.UnitPrice).NotEmpty();

            RuleFor(x => x.VatId).NotEmpty().WithMessage("Vat Rate Not Empty");

            RuleFor(x => x.WarehouseId).NotEmpty().WithMessage("Warehouse Name Not Empty");
        }
    }
}
