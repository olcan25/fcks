using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator:AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();

            RuleFor(x => x.AccountId).NotEmpty().WithMessage("Cash Account Not Empty");

            RuleFor(x => x.PartnerId).NotEmpty().WithMessage("Partner Name Not Empty");

            RuleFor(x => x.PaymentTypeId).NotEmpty().WithMessage("Payment Type Not Empty");
        }
    }
}
