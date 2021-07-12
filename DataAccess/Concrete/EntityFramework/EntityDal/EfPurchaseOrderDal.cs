using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.Dto.Product;
using Entity.Dto.PurchaseOrder;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfPurchaseOrderDal : EfEntityRepositoryBase<PurchaseOrder, InventoryManagementContext>, IPurchaseOrderDal
    {
        public List<GetPurchaseOrderDto> GetAllPurchaseOrderDtos(Expression<Func<GetPurchaseOrderDto, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var purchaseOrderLines = from purchaseOrderLine in context.PurchaseOrderLines
                                     group purchaseOrderLine by purchaseOrderLine.PurchaseOrderId
                into pol
                                     select new
                                     {
                                         PurchaseOrderId = pol.Key,
                                         AmountVatValue = pol.Sum(p => p.VatAmount),
                                         Amount = pol.Sum(p => p.Amount),
                                         AmountWithVat = pol.Sum(p => p.GrossAmount)
                                     };

            var result = from purchaseOrder in context.PurchaseOrders
                         join partner in context.Partners on purchaseOrder.PartnerId equals partner.Id
                         join ledger in context.Ledgers on purchaseOrder.LedgerId equals ledger.Id
                         join purchaseOrderLine in purchaseOrderLines on purchaseOrder.Id equals purchaseOrderLine.PurchaseOrderId
                         select new GetPurchaseOrderDto()
                         {
                             Id = purchaseOrder.Id,
                             LedgerId = ledger.Id,
                             PartnerName = partner.Name,
                             PurchaseOrderDescription = purchaseOrder.Description,
                             LedgerDescription = ledger.Description,
                             Note = purchaseOrder.Description,
                             InvoiceNumber = purchaseOrder.InvoiceNumber,
                             RegisterDate = ledger.RegisterDate,
                             IsPaid = purchaseOrder.IsPaid,
                             AmountVatValue = purchaseOrderLine.AmountVatValue,
                             Amount = purchaseOrderLine.Amount,
                             AmountWithVat = purchaseOrderLine.AmountWithVat
                         };
            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
        }

        public GetPurchaseOrderDto GetPurchaseOrderDto(Expression<Func<GetPurchaseOrderDto, bool>> filter)
        {
            using var context = new InventoryManagementContext();
            var purchaseOrderLines = from purchaseOrderLine in context.PurchaseOrderLines
                                     group purchaseOrderLine by purchaseOrderLine.PurchaseOrderId
                into pol
                                     select new
                                     {
                                         PurchaseOrderId = pol.Key,
                                         AmountVatValue = pol.Sum(p => p.VatAmount),
                                         Amount = pol.Sum(p => p.Amount),
                                         AmountWithVat = pol.Sum(p => p.GrossAmount)
                                     };
            var result = from purchaseOrder in context.PurchaseOrders
                         join partner in context.Partners on purchaseOrder.PartnerId equals partner.Id
                         join ledger in context.Ledgers on purchaseOrder.LedgerId equals ledger.Id
                         join purchaseOrderLine in purchaseOrderLines on purchaseOrder.Id equals purchaseOrderLine.PurchaseOrderId
                         select new GetPurchaseOrderDto()
                         {
                             Id = purchaseOrder.Id,
                             LedgerId = ledger.Id,
                             PartnerName = partner.Name,
                             PurchaseOrderDescription = purchaseOrder.Description,
                             LedgerDescription = ledger.Description,
                             Note = purchaseOrder.Description,
                             InvoiceNumber = purchaseOrder.InvoiceNumber,
                             RegisterDate = ledger.RegisterDate,
                             IsPaid = purchaseOrder.IsPaid,
                             AmountVatValue = purchaseOrderLine.AmountVatValue,
                             Amount = purchaseOrderLine.Amount,
                             AmountWithVat = purchaseOrderLine.AmountWithVat
                         };
            return result.FirstOrDefault(filter);
        }
    }
}
