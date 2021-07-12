using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Concrete;
using Entity.Dto.PurchaseOrderLine;

namespace Business.Mapping.AutoMapper
{
    public class PurchaseOrderLineMapping:Profile
    {
        public PurchaseOrderLineMapping()
        {
            CreateMap<PurchaseOrderLineDto, PurchaseOrderLine>().ReverseMap();
        }
    }
}
