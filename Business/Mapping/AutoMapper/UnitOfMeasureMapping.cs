using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entity.Concrete;
using Entity.Dto.UnitOfMeasure;

namespace Business.Mapping.AutoMapper
{
    public class UnitOfMeasureMapping : Profile
    {
        public UnitOfMeasureMapping()
        {
            CreateMap<DtoUnitOfMeasure, UnitOfMeasure>();

            CreateMap<UnitOfMeasure, GetDtoUnitOfMeasure>();
        }
    }
}
