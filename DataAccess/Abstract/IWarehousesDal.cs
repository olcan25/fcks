using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto.Warehouse;

namespace DataAccess.Abstract
{
    public interface IWarehousesDal : IEntityRepository<Warehouse>
    {
        List<DtoWarehouse> GetAllDtoWarehouses(Expression<Func<DtoWarehouse, bool>> filter = null);
        DtoWarehouse GetDtoWarehouse(Expression<Func<DtoWarehouse, bool>> filter);
    }
}
