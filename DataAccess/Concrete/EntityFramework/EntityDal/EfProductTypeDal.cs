using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfProductTypeDal:EfEntityRepositoryBase<ProductType,InventoryManagementContext>,IProductTypeDal
    {
    }
}
