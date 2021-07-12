using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entity.Concrete;
using Entity.Dto.CompanyBankAccount;

namespace Business.Mapping.AutoMapper
{
    public class CompanyBankAccountMapping : Profile
    {
        public CompanyBankAccountMapping()
        {
            CreateMap<DtoCompanyBankAccount, CompanyBankAccount>();

            CreateMap<CompanyBankAccount, GetDtoCompanyBankAccount>();
        }
    }
}
