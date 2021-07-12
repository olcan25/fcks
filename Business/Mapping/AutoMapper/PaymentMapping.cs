using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Concrete;

namespace Business.Mapping.AutoMapper
{
    public class PaymentMapping : Profile
    {
        public PaymentMapping()
        {
            CreateMap<PurchaseOrder, Payment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(d => 1))
                .ForMember(dest => dest.PaymentTypeId, opt => opt.MapFrom(d => 1));

            CreateMap<List<PurchaseOrderLine>, Payment>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(x => x.Sum(y => y.GrossAmount)));

            CreateMap<WholeSaleOrder, Payment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(d => 1))
                .ForMember(dest => dest.PaymentTypeId, opt => opt.MapFrom(d => 1));

            CreateMap<List<WholeSaleOrderLine>, Payment>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(x => x.Sum(y => y.AmountWithVat)));

        }
    }
}
