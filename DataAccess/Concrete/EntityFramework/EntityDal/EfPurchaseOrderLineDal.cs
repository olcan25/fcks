using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using EFCore.BulkExtensions;
using Entity.Concrete;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfPurchaseOrderLineDal : EfEntityRepositoryBase<PurchaseOrderLine, InventoryManagementContext>,
        IPurchaseOrderLineDal
    {
        public override void BulkSynchronize(List<PurchaseOrderLine> entities,BulkConfig bulkConfig=null)
        {
            
            using var context = new InventoryManagementContext();
            long purchaseOrderId = entities.Select(purchaseOrderLine => purchaseOrderLine.PurchaseOrderId).FirstOrDefault();
            context.PurchaseOrderLines.ToLinqToDBTable()
                .Merge()
                     .Using(entities)
                     .On((t, s) => t.Id == s.Id)
                     .UpdateWhenMatchedAnd((t, s) => t.Id == s.Id)
                     .InsertWhenNotMatched()
                     .DeleteWhenNotMatchedBySourceAnd(p => p.PurchaseOrderId == purchaseOrderId)
                     .Merge();
        }
    }
}
