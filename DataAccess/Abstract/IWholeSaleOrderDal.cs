using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto.Invoice;
using Entity.Dto.WholeSaleOrder;

namespace DataAccess.Abstract
{
    public interface IWholeSaleOrderDal : IEntityRepository<WholeSaleOrder>
    {
        List<GetWholeSaleOrderDto> GetAllWholeSaleOrdersDto(Expression<Func<GetWholeSaleOrderDto, bool>> filter = null);
        GetWholeSaleOrderDto GetWholeSaleOrderDto(Expression<Func<GetWholeSaleOrderDto, bool>> filter);
        List<InvoiceHead> GetAllInvoiceHeads(Expression<Func<InvoiceHead, bool>> filter = null);
        InvoiceHead GetByIdInvoiceHead(Expression<Func<InvoiceHead, bool>> filter);
    }
}
