using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using EFCore.BulkExtensions;
using Entity.Concrete;
using Entity.Dto.Invoice;
using Entity.Dto.WholeSaleOrder;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfWholeSaleOrderLineDal : EfEntityRepositoryBase<WholeSaleOrderLine, InventoryManagementContext>, IWholeSaleOrderLineDal
    {
        public override void BulkSynchronize(List<WholeSaleOrderLine> entities, BulkConfig bulkConfig = null)
        {

            //using var context = new InventoryManagementContext();
            //int wholeSaleOrderId = entities.Select(wholeSaleOrderLine => wholeSaleOrderLine.WholeSaleOrderId)
            //    .FirstOrDefault();

            //context.WholeSaleOrderLines.ToLinqToDBTable()
            //    .Merge()
            //    .Using(entities)
            //    .On((t, s) => t.Id == s.Id)
            //    .UpdateWhenMatchedAnd((t, s) => t.Id == s.Id)
            //    .InsertWhenNotMatched()
            //    .DeleteWhenNotMatchedBySourceAnd(p => p.WholeSaleOrderId == wholeSaleOrderId)
            //    .Merge();

            using var context = new InventoryManagementContext();
            long wholeSaleOrderId = entities.Select(wholeSaleOrderLine => wholeSaleOrderLine.WholeSaleOrderId).FirstOrDefault();
            context.WholeSaleOrderLines.ToLinqToDBTable()
                .Merge()
                     .Using(entities)
                     .On((t, s) => t.Id == s.Id)
                     .UpdateWhenMatchedAnd((t, s) => t.Id == s.Id)
                     .InsertWhenNotMatched()
                     .DeleteWhenNotMatchedBySourceAnd(p => p.WholeSaleOrderId == wholeSaleOrderId)
                     .Merge();
        }

        public List<InvoiceLine> GetAllInvoiceLines(Expression<Func<InvoiceLine, bool>> filter = null)
        {
            using (var context = new InventoryManagementContext())
            {
                var result = from product in context.Products
                             join unitOfMeasure in context.UnitOfMeasures on product.UnitOfMeasureId equals unitOfMeasure.Id
                             join wholeSaleOrderLine in context.WholeSaleOrderLines on product.Id equals wholeSaleOrderLine
                                 .ProductId
                             join vat in context.Vats on product.VatId equals vat.Id
                             //       join productBarcode in context.ProductBarcodes on product.Id equals productBarcode.ProductId 
                             select new InvoiceLine()
                             {
                                 Id = wholeSaleOrderLine.Id,
                                 //      ProductBarcode = productBarcode.Barcode,
                                 VatId = product.VatId,
                                 VatRate = vat.Rate,
                                 WholeSaleOrderId = wholeSaleOrderLine.WholeSaleOrderId,
                                 ProductName = product.Name,
                                 UnitOfMeasureShortName = unitOfMeasure.ShortName,
                                 Quantity = wholeSaleOrderLine.Quantity,
                                 UnitPrice = wholeSaleOrderLine.UnitPrice,
                                 UnitPriceWithVat = wholeSaleOrderLine.UnitPriceWithVat,
                                 UnitPriceVatValue = wholeSaleOrderLine.VatUnitPrice,
                                 UnitPriceDiscountValue = wholeSaleOrderLine.DiscountUnitPrice,
                                 DiscountRate = wholeSaleOrderLine.DiscountRate,
                                 AmountDiscountValue = wholeSaleOrderLine.DiscountAmount,
                                 Amount = wholeSaleOrderLine.Amount,
                                 AmountVatValue = wholeSaleOrderLine.VatAmount,
                                 AmountWithVat = wholeSaleOrderLine.AmountWithVat
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();

            }
        }
    }
}
