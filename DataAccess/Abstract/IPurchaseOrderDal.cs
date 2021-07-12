using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto.Product;
using Entity.Dto.PurchaseOrder;

namespace DataAccess.Abstract
{
    public interface IPurchaseOrderDal : IEntityRepository<PurchaseOrder>
    {
        List<GetPurchaseOrderDto> GetAllPurchaseOrderDtos(Expression<Func<GetPurchaseOrderDto, bool>> filter = null);
        GetPurchaseOrderDto GetPurchaseOrderDto(Expression<Func<GetPurchaseOrderDto, bool>> filter);
    }
}
