using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Concrete;
using Entity.Dto.User;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserRegisterForDtoValidator:AbstractValidator<UserForRegisterDto>
    {
        public UserRegisterForDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty();

            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.FirstName).NotEmpty();

            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(5);
        }
    }
}
