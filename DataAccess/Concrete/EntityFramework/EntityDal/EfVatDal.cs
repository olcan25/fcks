using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfVatDal : EfEntityRepositoryBase<Vat, InventoryManagementContext>, IVatDal
    {
    }
}
