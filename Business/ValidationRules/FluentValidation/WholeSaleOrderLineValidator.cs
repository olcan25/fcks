using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WholeSaleOrderLineValidator:AbstractValidator<WholeSaleOrderLine>
    {
        public WholeSaleOrderLineValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();

            RuleFor(x => x.ProductId).NotEmpty();

            RuleFor(x => x.Quantity).NotEmpty();

            RuleFor(x => x.UnitPrice).NotEmpty();

            RuleFor(x => x.VatId).NotEmpty();

            RuleFor(x => x.WarehouseId).NotEmpty();
        }
    }
}
