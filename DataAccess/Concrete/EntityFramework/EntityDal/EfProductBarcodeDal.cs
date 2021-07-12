using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using EFCore.BulkExtensions;
using Entity.Concrete;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfProductBarcodeDal : EfEntityRepositoryBase<ProductBarcode, InventoryManagementContext>, IProductBarcodeDal
    {
        public override void BulkSynchronize(List<ProductBarcode> entities,BulkConfig bulkConfig=null)
        {
            using var context = new InventoryManagementContext();
            context.ProductBarcodes.ToLinqToDBTable()
                .Merge()
                .Using(entities)
                .On((t, s) => t.Id == s.Id)
                .UpdateWhenMatchedAnd((t, s) => t.Id == s.Id)
                .InsertWhenNotMatched()
                .DeleteWhenNotMatchedBySource()
                .Merge();
        }
    }
}
