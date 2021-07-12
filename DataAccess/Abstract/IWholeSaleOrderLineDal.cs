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
    public interface IWholeSaleOrderLineDal:IEntityRepository<WholeSaleOrderLine>
    {
        List<InvoiceLine> GetAllInvoiceLines(Expression<Func<InvoiceLine, bool>> filter = null);
    }
}
