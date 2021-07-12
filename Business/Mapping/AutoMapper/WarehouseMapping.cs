using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entity.Concrete;
using Entity.Dto.Warehouse;

namespace Business.Mapping.AutoMapper
{
    public class WarehouseMapping : Profile
    {
        public WarehouseMapping()
        {
            CreateMap<DtoWarehouse, Warehouse>();

            CreateMap<Warehouse, DtoWarehouse>();

            CreateMap<Warehouse, Account>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => 153000 + x.Id))
                .ForMember(dest => dest.Name, src => src.MapFrom(x => "Ticari Mallar " + x.Name))
                .ForMember(dest => dest.AccountTypeId, src => src.MapFrom(x => 1));
        }
    }
}
