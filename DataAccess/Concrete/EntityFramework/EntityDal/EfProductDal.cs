using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using EFCore.BulkExtensions;
using Entity.Concrete;
using Entity.Dto.Product;
using Entity.DtoLinq;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfProductDal : EfEntityRepositoryBase<Product, InventoryManagementContext>, IProductDal
    {
        public List<DtoProduct> GetAllDtoProducts(Expression<Func<DtoProduct, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var result = from product in context.Products
                         join category in context.Categories on product.CategoryId equals category.Id
                         join unitOfMeasure in context.UnitOfMeasures on product.UnitOfMeasureId equals unitOfMeasure.Id
                         join vat in context.Vats on product.VatId equals vat.Id
                         join productType in context.ProductTypes on product.ProductTypeId equals productType.Id
                         select new DtoProduct()
                         {
                             Id = product.Id,
                             VatRate = vat.Name,
                             CategoryName = category.Name,
                             UnitOfMeasureName = unitOfMeasure.ShortName,
                             Name = product.Name,
                             Description = product.Description,
                             DefaultSellingPrice = product.DefaultSellingPrice,
                             DefaultBuyingPrice = product.DefaultBuyingPrice,
                             ProductTypeName = productType.Name,
                             ImagePath = product.ImagePath
                         };

            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
        }

        public DtoProduct GetDtoProduct(Expression<Func<DtoProduct, bool>> filter)
        {
            using var context = new InventoryManagementContext();
            var result = from product in context.Products
                         join category in context.Categories on product.CategoryId equals category.Id
                         join unitOfMeasure in context.UnitOfMeasures on product.UnitOfMeasureId equals unitOfMeasure.Id
                         join vat in context.Vats on product.VatId equals vat.Id
                         join productType in context.ProductTypes on product.ProductTypeId equals productType.Id
                         select new DtoProduct()
                         {
                             Id = product.Id,
                             VatRate = vat.Name,
                             CategoryName = category.Name,
                             UnitOfMeasureName = unitOfMeasure.ShortName,
                             Name = product.Name,
                             Description = product.Description,
                             DefaultSellingPrice = product.DefaultSellingPrice,
                             DefaultBuyingPrice = product.DefaultBuyingPrice,
                             ProductTypeName = productType.Name,
                             ImagePath = product.ImagePath
                         };

            return result.FirstOrDefault(filter);
        }

        public List<DtoCardOfProduct> GetAAllCardOdProducts(Expression<Func<DtoCardOfProduct, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var purchaseOrders = from purchaseOrder in context.PurchaseOrders
                                 join partner in context.Partners on purchaseOrder.PartnerId equals partner.Id
                                 join ledger in context.Ledgers on purchaseOrder.LedgerId equals ledger.Id
                                 select new
                                 {
                                     LedgerId = ledger.Id,
                                     PurchaseOrderId = purchaseOrder.Id,
                                     PartnerName = partner.Name,
                                     RegisterDate = ledger.RegisterDate
                                 };
            var purchaseOrderLines = from product in context.Products
                                     join purchaseOrderLine in context.PurchaseOrderLines on product.Id equals purchaseOrderLine.ProductId into purchaseOrderLineTemp
                                     from purchaseOrderLine in purchaseOrderLineTemp.DefaultIfEmpty()
                                     join warehouse in context.Warehouses on purchaseOrderLine.WarehouseId equals warehouse.Id into warehouseTemp
                                     from warehouse in warehouseTemp.DefaultIfEmpty()
                                     join purchaseOrder in purchaseOrders on purchaseOrderLine.PurchaseOrderId equals purchaseOrder
                                         .PurchaseOrderId
                                     select new DtoCardOfProduct()
                                     {
                                         ProductId = product.Id,
                                         ProductName = product.Name,
                                         InQuantity = purchaseOrderLine.Quantity,
                                         OutQuantity = 0,
                                         PartnerName = purchaseOrder.PartnerName,
                                         RegisterDate = purchaseOrder.RegisterDate,
                                         UnitPrice = purchaseOrderLine.UnitPrice ?? 0,
                                         UnitPriceWithVat = purchaseOrderLine.GrossUnitPrice ?? 0,
                                         Balance = purchaseOrderLine.Quantity ?? 0
                                     };

            var wholeSaleOrders = from wholeSaleOrder in context.WholeSaleOrders
                                  join partner in context.Partners on wholeSaleOrder.PartnerId equals partner.Id
                                  join ledger in context.Ledgers on wholeSaleOrder.LedgerId equals ledger.Id
                                  select new
                                  {
                                      LedgerId = ledger.Id,
                                      WholeSaleOrderId = wholeSaleOrder.Id,
                                      PartnerName = partner.Name,
                                      RegisterDate = ledger.RegisterDate
                                  };
            var wholeSaleOrderLines = from product in context.Products
                                      join wholeSaleOrderLine in context.WholeSaleOrderLines on product.Id equals wholeSaleOrderLine.ProductId into wholeSaleOrderLineTemp
                                      from wholeSaleOrderLine in wholeSaleOrderLineTemp.DefaultIfEmpty()
                                      join warehouse in context.Warehouses on wholeSaleOrderLine.WarehouseId equals warehouse.Id into warehouseTemp
                                      from warehouse in warehouseTemp.DefaultIfEmpty()
                                      join wholeSaleOrder in wholeSaleOrders on wholeSaleOrderLine.WholeSaleOrderId equals wholeSaleOrder
                                          .WholeSaleOrderId
                                      select new DtoCardOfProduct()
                                      {
                                          ProductId = product.Id,
                                          ProductName = product.Name,
                                          InQuantity = 0,
                                          OutQuantity = wholeSaleOrderLine.Quantity,
                                          PartnerName = wholeSaleOrder.PartnerName,
                                          RegisterDate = wholeSaleOrder.RegisterDate,
                                          UnitPrice = wholeSaleOrderLine.UnitPrice ?? 0,
                                          UnitPriceWithVat = wholeSaleOrderLine.UnitPriceWithVat ?? 0,
                                          Balance = -wholeSaleOrderLine.Quantity ?? 0
                                      };


            var result = purchaseOrderLines.Union(wholeSaleOrderLines);


            result = result.OrderBy(x => x.RegisterDate);

            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
        }

        public List<DtoConditionOfProduct> GetAllConditionOfProducts(Expression<Func<DtoConditionOfProduct, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var purchaseOrderLines = from purchaseOrderLine in context.PurchaseOrderLines
                                     group purchaseOrderLine by purchaseOrderLine.ProductId
                into pol
                                     select new
                                     {
                                         ProductId = pol.Key,
                                         InQuantity = pol.Sum(x => x.Quantity),
                                         InAvarageUnitPrice = pol.Sum(x => (x.Quantity ?? 0) * (x.UnitPrice ?? 0)) / pol.Sum(x => x.Quantity ?? 0) /*pol.Sum(x => (x.UnitPrice ?? 0) * (x.Quantity ?? 0)) / pol.Sum(x => (x.Quantity ?? 0))*/,
                                         InAvaregeAmount = pol.Sum(x => (x.UnitPrice ?? 0) * (x.Quantity ?? 0)),
                                         //InFirstUnitPrice = pol.Select(x=>x.UnitPrice).First(),
                                         //InFirstAmount = pol.Select(x=>x.UnitPrice).First() * pol.Select(x=>x.Quantity).First(),
                                         //InLastUnitPrice = pol.Select(x=>x.UnitPrice).Last(),
                                         //InLastAmount = pol.Select(x=>x.UnitPrice).Last() * pol.Select(x=>x.Quantity).Last()
                                     };
            var wholeSaleOrderLines = from wholeSaleOrderLine in context.WholeSaleOrderLines
                                      group wholeSaleOrderLine by wholeSaleOrderLine.ProductId
                into wol
                                      select new
                                      {
                                          ProductId = wol.Key,
                                          OutQuantity = wol.Sum(w => (w.Quantity ?? 0)),
                                          OutUnitPrice = wol.Average(x => (x.UnitPrice ?? 0)),
                                          OutUnitPriceWithVat = wol.Average(x => (x.UnitPriceWithVat ?? 0)),
                                          //OutFirstUnitPrice = wol.Select(x => x.UnitPrice).First(),
                                          //OutFirstAmount = wol.Select(x => x.UnitPrice).First() * wol.Select(x => x.Quantity).First(),
                                          //OutLastUnitPrice = wol.Select(x => x.UnitPrice).Last(),
                                          //OutLastAmount = wol.Select(x => x.UnitPrice).Last() * wol.Select(x => x.Quantity).Last()
                                      };

            var result = from product in context.Products
                         join purchaseOrderLine in purchaseOrderLines on product.Id equals purchaseOrderLine.ProductId into purchaseOrderLineTemp
                         from purchaseOrderLine in purchaseOrderLineTemp.DefaultIfEmpty()
                         join wholeSaleOrderLine in wholeSaleOrderLines on product.Id equals wholeSaleOrderLine.ProductId into wholeSaleOrderLineTemp
                         from wholeSaleOrderLine in wholeSaleOrderLineTemp.DefaultIfEmpty()
                         select new DtoConditionOfProduct()
                         {
                             ProductId = product.Id,
                             ProductName = product.Name,
                             InQuantity = purchaseOrderLine.InQuantity,
                             InAvaregeUnitPrice = purchaseOrderLine.InAvarageUnitPrice,
                             InAvarageAmount = ((purchaseOrderLine.InQuantity ?? 0) - ((decimal?)wholeSaleOrderLine.OutQuantity ?? 0)) * (decimal?)purchaseOrderLine.InAvarageUnitPrice,
                             OutQuantity = wholeSaleOrderLine.OutQuantity,
                             OutUnitPrice = wholeSaleOrderLine.OutUnitPrice,
                             OutAmount = wholeSaleOrderLine.OutUnitPriceWithVat,
                             Balance = purchaseOrderLine.InQuantity - wholeSaleOrderLine.OutQuantity
                         };

            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
        }

        //Date Kiyaslamada bi ara bak lzm olmasin yabisi
        //sum kmsh total yap bi ara
        public List<DtoConditionOfProduct> GetAllConditionOfProducts(DateTime startDate, DateTime endDate, Expression<Func<DtoConditionOfProduct, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var purchaseOrderLines = from ledger in context.Ledgers
                                     join purchaseOrder in context.PurchaseOrders on ledger.Id equals purchaseOrder.LedgerId
                                     join purchaseOrderLine in context.PurchaseOrderLines on purchaseOrder.Id equals purchaseOrderLine.PurchaseOrderId
                                     where ledger.RegisterDate >= startDate && ledger.RegisterDate <= endDate
                                     group purchaseOrderLine by purchaseOrderLine.ProductId into p
                                     select new
                                     {
                                         ProductId = (long?)p.Key,
                                         InQuantity = (decimal?)p.Sum(x => x.Quantity),
                                         InAvarageUnitPrice = (decimal?)p.Sum(x => x.Amount) / (decimal?)p.Sum(x => x.Quantity)
                                     };

            var wholeSaleOrderLines = from ledger in context.Ledgers
                                      join wholeSaleOrder in context.WholeSaleOrders on ledger.Id equals wholeSaleOrder.LedgerId
                                      join wholeSaleOrderLine in context.WholeSaleOrderLines on wholeSaleOrder.Id equals wholeSaleOrderLine.WholeSaleOrderId
                                      where ledger.RegisterDate >= startDate && ledger.RegisterDate <= endDate
                                      group wholeSaleOrderLine by wholeSaleOrderLine.ProductId into p
                                      select new
                                      {
                                          ProductId = (long?)p.Key,
                                          OutQuantity = (decimal?)p.Sum(x => x.Quantity)
                                      };


            var result = from product in context.Products
                         join purchaseOrderLine in purchaseOrderLines on product.Id equals purchaseOrderLine.ProductId into purchaseOrderLineTemp
                         from purchaseOrderLine in purchaseOrderLineTemp.DefaultIfEmpty()
                         join wholeSaleOrderLine in wholeSaleOrderLines on product.Id equals wholeSaleOrderLine.ProductId into wholeSaleOrderLineTemp
                         from wholeSaleOrderLine in wholeSaleOrderLineTemp.DefaultIfEmpty()
                         select new DtoConditionOfProduct
                         {
                             ProductId = product.Id,
                             ProductName = product.Name,
                             InQuantity = (decimal?)purchaseOrderLine.InQuantity,
                             InAvaregeUnitPrice = (decimal?)purchaseOrderLine.InAvarageUnitPrice,
                             InAvarageAmount = ((decimal?)purchaseOrderLine.InQuantity - ((decimal?)wholeSaleOrderLine.OutQuantity ?? 0)) * (decimal?)purchaseOrderLine.InAvarageUnitPrice,
                             OutQuantity = (decimal?)wholeSaleOrderLine.OutQuantity,
                             Balance = ((decimal?)purchaseOrderLine.InQuantity ?? 0) - ((decimal?)wholeSaleOrderLine.OutQuantity ?? 0)
                         };

            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();


        }

    }
}