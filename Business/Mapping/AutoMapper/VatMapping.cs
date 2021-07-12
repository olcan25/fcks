using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entity.Concrete;
using Entity.Dto.Vat;

namespace Business.Mapping.AutoMapper
{
    public class VatMapping : Profile
    {
        public VatMapping()
        {
            CreateMap<DtoVat, Vat>();

            CreateMap<Vat, GetDtoVat>();
        }
    }
}
