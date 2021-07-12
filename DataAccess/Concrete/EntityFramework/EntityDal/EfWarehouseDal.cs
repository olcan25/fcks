using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.Dto.Warehouse;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfWarehouseDal : EfEntityRepositoryBase<Warehouse, InventoryManagementContext>, IWarehousesDal
    {
        public List<DtoWarehouse> GetAllDtoWarehouses(Expression<Func<DtoWarehouse, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var result = from warehouse in context.Warehouses
                         join company in context.Companies on warehouse.CompanyId equals company.Id
                         select new DtoWarehouse()
                         {
                             Id = warehouse.Id,
                             Name = warehouse.Name,
                             CompanyName = company.Name,
                             AddressDetail = warehouse.AddressDetail,
                             City = warehouse.City,
                             Country = warehouse.Country,
                             ZipCode = warehouse.ZipCode
                         };
            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
        }

        public DtoWarehouse GetDtoWarehouse(Expression<Func<DtoWarehouse, bool>> filter)
        {
            using var context = new InventoryManagementContext();
            var result = from warehouse in context.Warehouses
                         join company in context.Companies on warehouse.CompanyId equals company.Id
                         select new DtoWarehouse()
                         {
                             Id = warehouse.Id,
                             Name = warehouse.Name,
                             CompanyName = company.Name,
                             AddressDetail = warehouse.AddressDetail,
                             City = warehouse.City,
                             Country = warehouse.Country,
                             ZipCode = warehouse.ZipCode
                         };
            return result.FirstOrDefault(filter);
        }
    }
}
