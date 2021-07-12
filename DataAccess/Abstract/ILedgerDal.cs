using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface ILedgerDal : IEntityRepository<Ledger>
    {
        Ledger GetLedgerWithPurchase(Expression<Func<Ledger, bool>> filter);
        Ledger GetLedgerWithWholeSale(Expression<Func<Ledger, bool>> filter);

    }
}
