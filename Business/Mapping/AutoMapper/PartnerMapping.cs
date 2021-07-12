using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entity.Concrete;
using Entity.Dto.Partner;

namespace Business.Mapping.AutoMapper
{
    public class PartnerMapping : Profile
    {
        public PartnerMapping()
        {
            CreateMap<DtoPartner, Partner>();

            CreateMap<Partner, GetDtoPartner>();
        }
    }
}
