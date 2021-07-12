using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using EFCore.BulkExtensions;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfLedgerDal : EfEntityRepositoryBase<Ledger, InventoryManagementContext>, ILedgerDal
    {
        public Ledger GetLedgerWithPurchase(Expression<Func<Ledger, bool>> filter)
        {
            using var context = new InventoryManagementContext();
            return context.Ledgers.Include(x => x.PurchaseOrders).ThenInclude(y => y.PurchaseOrderLines).FirstOrDefault(filter);
        }

        public Ledger GetLedgerWithWholeSale(Expression<Func<Ledger, bool>> filter)
        {
            using var context = new InventoryManagementContext();
            return context.Ledgers.Include(x => x.WholeSaleOrders).ThenInclude(x => x.WholeSaleOrderLines).FirstOrDefault(filter);
        }
    }
}
