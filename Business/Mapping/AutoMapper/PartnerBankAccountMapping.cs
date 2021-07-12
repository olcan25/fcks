using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entity.Concrete;
using Entity.Dto.PartnerBankAccount;

namespace Business.Mapping.AutoMapper
{
    public class PartnerBankAccountMapping : Profile
    {
        public PartnerBankAccountMapping()
        {
            CreateMap<PartnerByIdBankAccount, PartnerBankAccount>();

            CreateMap<PartnerBankAccount, DtoPartnerBankAccount>();
        }
    }
}
