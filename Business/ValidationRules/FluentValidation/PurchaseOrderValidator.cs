using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PurchaseOrderValidator:AbstractValidator<PurchaseOrder>
    {
        public PurchaseOrderValidator()
        {
            RuleFor(x => x.InvoiceNumber).NotEmpty();
            RuleFor(x => x.InvoiceNumber).MaximumLength(30);

            RuleFor(x => x.PartnerId).NotEmpty().WithMessage("Partner Name Not Empty");
        }
    }
}
