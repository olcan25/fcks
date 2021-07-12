using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WholeSaleOrderValidator:AbstractValidator<WholeSaleOrder>
    {
        public WholeSaleOrderValidator()
        {
            RuleFor(x => x.WholeSaleOrderNumber).NotEmpty();

            RuleFor(x => x.PartnerId).NotEmpty();
        }
    }
}
