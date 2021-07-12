using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Concrete;
using Entity.Dto.PurchaseOrder;

namespace Business.Mapping.AutoMapper
{
    public class PurchaseOrderMapping:Profile
    {
        public PurchaseOrderMapping()
        {
            CreateMap<PurchaseOrderDto, PurchaseOrder>().ReverseMap();
        }
    }
}
