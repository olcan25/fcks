using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.Product;
using Entity.DtoLinq;

namespace Business.Mapping.AutoMapper
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<DtoProduct, Product>();

            CreateMap<Product, GetDtoProduct>();

            CreateMap<PurchaseOrderLine, Product>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.ProductId))
                .ForMember(dest => dest.DefaultBuyingPrice, src => src.MapFrom(x => x.GrossUnitPrice));

            CreateMap<WholeSaleOrderLine, Product>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.ProductId))
                .ForMember(dest => dest.DefaultBuyingPrice, src => src.MapFrom(x => x.UnitPriceWithVat));

        }
    }
}
