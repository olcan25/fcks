using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entity.Concrete;
using Entity.Dto.Bank;

namespace Business.Mapping.AutoMapper
{
    public class BankMapping : Profile
    {
        public BankMapping()
        {
            CreateMap<Bank, DtoGetBank>();
            CreateMap<Bank, DtoBank>();
        }
    }
}
