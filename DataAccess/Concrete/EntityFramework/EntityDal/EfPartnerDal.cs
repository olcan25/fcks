using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.Dto.Partner;
using LinqToDB;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfPartnerDal : EfEntityRepositoryBase<Partner, InventoryManagementContext>, IPartnerDal
    {
        public List<DtoConditionOfPartner> GetAllConditionOfPartners(Expression<Func<DtoConditionOfPartner, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var purchaseOrders = from purchaseOrder in context.PurchaseOrders
                                 join purchaseOrderLine in context.PurchaseOrderLines on purchaseOrder.Id equals purchaseOrderLine
                                     .PurchaseOrderId
                                 select new
                                 {
                                     PartnerId = purchaseOrder.PartnerId,
                                     AmountWithVat = purchaseOrderLine.GrossAmount
                                 };

            var purchaseOrderGroups = from purchaseOrder in purchaseOrders
                                      group purchaseOrder by purchaseOrder.PartnerId
                into pol
                                      select new
                                      {
                                          PartnerId = pol.Key,
                                          PurchaseAmountWithVat = pol.Sum(x => x.AmountWithVat)
                                      };

            var wholeSaleOrders = from wholeSaleOrder in context.WholeSaleOrders
                                  join wholeSaleOrderLine in context.WholeSaleOrderLines on wholeSaleOrder.Id equals wholeSaleOrderLine
                                      .WholeSaleOrderId
                                  select new
                                  {
                                      PartnerId = wholeSaleOrder.PartnerId,
                                      SaleAmountWithVat = wholeSaleOrderLine.AmountWithVat
                                  };
            var wholeSaleOrderGroups = from wholeSaleOrder in wholeSaleOrders
                                       group wholeSaleOrder by wholeSaleOrder.PartnerId
                into wol
                                       select new
                                       {
                                           PartnerId = wol.Key,
                                           SaleAmountWithVat = wol.Sum(x => x.SaleAmountWithVat)
                                       };

            var payments = context.Payments.GroupBy(x => x.PartnerId).Select(x => new
            {
                PartnerId = x.Key,
                Debt = x.Where(y => y.PaymentTypeId == 1).Sum(z => z.Amount),
                Credit = x.Where(y => y.PaymentTypeId == 2).Sum(z => z.Amount)
            });



            var result = from partner in context.Partners
                         join purchaseOrderGroup in purchaseOrderGroups on partner.Id equals purchaseOrderGroup.PartnerId into
                             purchaseTemp
                         from purchaseOrderGroup in purchaseTemp.DefaultIfEmpty()
                         join wholeSaleOrderGroup in wholeSaleOrderGroups on partner.Id equals wholeSaleOrderGroup.PartnerId into
                             saleTemp
                         from wholeSaleOrderGroup in saleTemp.DefaultIfEmpty()
                         join payment in payments on partner.Id equals payment.PartnerId into paymentTemp
                         from payment in paymentTemp.DefaultIfEmpty()
                         select new DtoConditionOfPartner()
                         {
                             PartnerId = partner.Id,
                             PartnerName = partner.Name,
                             UniqueIdentificationNumber = partner.UniqueIdentificationNumber,
                             VatNumber = partner.VatNumber,
                             Debt = (payment.Debt ?? 0) + (wholeSaleOrderGroup.SaleAmountWithVat ?? 0),
                             Credit = (payment.Credit ?? 0) +
                                      (purchaseOrderGroup.PurchaseAmountWithVat ?? 0),
                             Balance = (payment.Debt ?? 0) + (wholeSaleOrderGroup.SaleAmountWithVat ?? 0) - ((payment.Credit ?? 0) +
                                       (purchaseOrderGroup.PurchaseAmountWithVat ?? 0))
                         };
            //null kontrol yapildi ilerde azaltbuni
            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();

        }
        public List<DtoConditionOfPartner> GetAllConditionOfPartners(DateTime startDate, DateTime endDate, Expression<Func<DtoConditionOfPartner, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var purchaseOrders = from ledger in context.Ledgers
                                 join purchaseOrder in context.PurchaseOrders on ledger.Id equals purchaseOrder.LedgerId
                                 join purchaseOrderLine in context.PurchaseOrderLines on purchaseOrder.Id equals purchaseOrderLine
                                     .PurchaseOrderId
                                 where ledger.RegisterDate >= startDate && ledger.RegisterDate <= endDate
                                 select new
                                 {
                                     PartnerId = purchaseOrder.PartnerId,
                                     AmountWithVat = purchaseOrderLine.GrossAmount
                                 };

            var purchaseOrderGroups = from purchaseOrder in purchaseOrders
                                      group purchaseOrder by purchaseOrder.PartnerId
                into pol
                                      select new
                                      {
                                          PartnerId = pol.Key,
                                          PurchaseAmountWithVat = pol.Sum(x => x.AmountWithVat)
                                      };

            var wholeSaleOrders = from ledger in context.Ledgers
                                  join wholeSaleOrder in context.WholeSaleOrders on ledger.Id equals wholeSaleOrder.LedgerId
                                  join wholeSaleOrderLine in context.WholeSaleOrderLines on wholeSaleOrder.Id equals wholeSaleOrderLine
                                      .WholeSaleOrderId
                                  where ledger.RegisterDate >= startDate && ledger.RegisterDate <= endDate
                                  select new
                                  {
                                      PartnerId = wholeSaleOrder.PartnerId,
                                      SaleAmountWithVat = wholeSaleOrderLine.AmountWithVat
                                  };
            var wholeSaleOrderGroups = from wholeSaleOrder in wholeSaleOrders
                                       group wholeSaleOrder by wholeSaleOrder.PartnerId
                into wol
                                       select new
                                       {
                                           PartnerId = wol.Key,
                                           SaleAmountWithVat = wol.Sum(x => x.SaleAmountWithVat)
                                       };

            //var payments = context.Payments.GroupBy(x => x.PartnerId).Select(x => new
            //{
            //    PartnerId = x.Key,
            //    Debt = x.Where(y => y.PaymentTypeId == 1).Sum(z => z.Amount),
            //    Credit = x.Where(y => y.PaymentTypeId == 2).Sum(z => z.Amount)
            //});

            var payments = from ledger in context.Ledgers
                           join payment in context.Payments on ledger.Id equals payment.LedgerId
                           where ledger.RegisterDate >= startDate && ledger.RegisterDate <= endDate
                           group payment by payment.PartnerId into p
                           select new
                           {
                               PartnerId = p.Key,
                               Debt = p.Where(y => y.PaymentTypeId == 1).Sum(z => z.Amount),
                               Credit = p.Where(y => y.PaymentTypeId == 2).Sum(z => z.Amount)
                           };





            var result = from partner in context.Partners
                         join purchaseOrderGroup in purchaseOrderGroups on partner.Id equals purchaseOrderGroup.PartnerId into
                             purchaseTemp
                         from purchaseOrderGroup in purchaseTemp.DefaultIfEmpty()
                         join wholeSaleOrderGroup in wholeSaleOrderGroups on partner.Id equals wholeSaleOrderGroup.PartnerId into
                             saleTemp
                         from wholeSaleOrderGroup in saleTemp.DefaultIfEmpty()
                         join payment in payments on partner.Id equals payment.PartnerId into paymentTemp
                         from payment in paymentTemp.DefaultIfEmpty()
                         select new DtoConditionOfPartner()
                         {
                             PartnerId = partner.Id,
                             PartnerName = partner.Name,
                             UniqueIdentificationNumber = partner.UniqueIdentificationNumber,
                             VatNumber = partner.VatNumber,
                             Debt = (payment.Debt ?? 0) + (wholeSaleOrderGroup.SaleAmountWithVat ?? 0),
                             Credit = (payment.Credit ?? 0) +
                                      (purchaseOrderGroup.PurchaseAmountWithVat ?? 0),
                             Balance = (payment.Debt ?? 0) + (wholeSaleOrderGroup.SaleAmountWithVat ?? 0) - ((payment.Credit ?? 0) +
                                       (purchaseOrderGroup.PurchaseAmountWithVat ?? 0))
                         };
            //null kontrol yapildi ilerde azaltbuni
            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
        }

        public List<DtoCardOfPartner> GetAllCardOfPartners(Expression<Func<DtoCardOfPartner, bool>> filter)
        {
            using var context = new InventoryManagementContext();
            var purchaseOrderLines = context.PurchaseOrderLines.GroupBy(x => x.PurchaseOrderId).Select(x =>
                 new { PurchaseOrderId = x.Key, AmountWithVat = x.Sum(y => y.GrossAmount) });

            var purchaseOrders = from purchaseOrder in context.PurchaseOrders
                                 join purchaseOrderLine in purchaseOrderLines on purchaseOrder.Id equals purchaseOrderLine
                                     .PurchaseOrderId
                                 join ledger in context.Ledgers on purchaseOrder.LedgerId equals ledger.Id
                                 //join partner in context.Partners on purchaseOrder.PartnerId equals partner.Id || purchaseOrder.part
                                 join partner in context.Partners on (long?)purchaseOrder.PartnerId ?? 0 + (long?)purchaseOrder.TransporterId ?? 0 equals partner.Id
                                 select new DtoCardOfPartner()
                                 {
                                     LedgerId = ledger.Id,
                                     RegisterDate = ledger.RegisterDate,
                                     Description = ledger.Description,
                                     PartnerId = partner.Id,
                                     PartnerName = partner.Name,
                                     InvoiceNumber = purchaseOrder.InvoiceNumber,
                                     Debt = 0,
                                     Credit = purchaseOrderLine.AmountWithVat ?? 0,
                                     Balance = -purchaseOrderLine.AmountWithVat ?? 0
                                 };

            var wholeSaleOrderLines = context.WholeSaleOrderLines.GroupBy(x => x.WholeSaleOrderId).Select(x =>
                new { WholeSaleOrderId = x.Key, AmountWithVat = x.Sum(y => y.AmountWithVat) });

            var wholeSaleOrders = from wholeSaleOrder in context.WholeSaleOrders
                                  join wholeSaleOrderLine in wholeSaleOrderLines on wholeSaleOrder.Id equals wholeSaleOrderLine.WholeSaleOrderId
                                  join ledger in context.Ledgers on wholeSaleOrder.LedgerId equals ledger.Id
                                  join partner in context.Partners on wholeSaleOrder.PartnerId equals partner.Id
                                  select new DtoCardOfPartner()
                                  {
                                      LedgerId = ledger.Id,
                                      RegisterDate = ledger.RegisterDate,
                                      Description = ledger.Description,
                                      PartnerId = partner.Id,
                                      PartnerName = partner.Name,
                                      InvoiceNumber = wholeSaleOrder.WholeSaleOrderNumber.ToString(),
                                      Debt = wholeSaleOrderLine.AmountWithVat ?? 0,
                                      Credit = 0,
                                      Balance = wholeSaleOrderLine.AmountWithVat ?? 0
                                  };

            var purchasePayments = from payment in context.Payments
                                   join ledger in context.Ledgers on payment.LedgerId equals ledger.Id
                                   join partner in context.Partners on payment.PartnerId equals partner.Id
                                   join paymentType in context.PaymentTypes on payment.PaymentTypeId equals paymentType.Id
                                   where payment.PaymentTypeId == 1
                                   select new DtoCardOfPartner()
                                   {
                                       LedgerId = ledger.Id,
                                       RegisterDate = ledger.RegisterDate,
                                       Description = ledger.Description,
                                       PartnerId = partner.Id,
                                       PartnerName = partner.Name,
                                       InvoiceNumber = payment.Id.ToString() + " " + paymentType.Name,
                                       Debt = payment.Amount ?? 0,
                                       Credit = 0,
                                       Balance = payment.Amount ?? 0
                                   };

            var salePayments = from payment in context.Payments
                               join ledger in context.Ledgers on payment.LedgerId equals ledger.Id
                               join partner in context.Partners on payment.PartnerId equals partner.Id
                               join paymentType in context.PaymentTypes on payment.PaymentTypeId equals paymentType.Id
                               where payment.PaymentTypeId == 2
                               select new DtoCardOfPartner()
                               {
                                   LedgerId = ledger.Id,
                                   RegisterDate = ledger.RegisterDate,
                                   Description = ledger.Description,
                                   PartnerId = partner.Id,
                                   PartnerName = partner.Name,
                                   InvoiceNumber = payment.Id.ToString() + " " + paymentType.Name,
                                   Debt = 0,
                                   Credit = payment.Amount ?? 0,
                                   Balance = -payment.Amount ?? 0
                               };

            var paymentPurchase = purchasePayments.Where(filter).AsEnumerable();
            var paymentSale = salePayments.Where(filter).AsEnumerable();

            var purchase = purchaseOrders.Where(filter).AsEnumerable();
            var sale = wholeSaleOrders.Where(filter).AsEnumerable();
            var result = purchase.Union(sale).Union(paymentPurchase).Union(paymentSale);

            return result.OrderBy(x => x.RegisterDate).ToList();


        }

    }
}