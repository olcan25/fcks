using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.Dto.Invoice;
using Entity.Dto.WholeSaleOrder;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfWholeSaleOrderDal : EfEntityRepositoryBase<WholeSaleOrder, InventoryManagementContext>, IWholeSaleOrderDal
    {
        public override void Add(WholeSaleOrder entity)
        {
            using (var context = new InventoryManagementContext())
            {
                var result = context.WholeSaleOrders;
                if (entity.WholeSaleOrderNumber == 0)
                {
                    if (!result.Any())
                    {
                        entity.WholeSaleOrderNumber = 1;
                    }
                    else
                    {
                        entity.WholeSaleOrderNumber = result.Count() + 1;
                    }
                }

                result.Add(entity);
                context.SaveChanges();

            }
        }

        public List<GetWholeSaleOrderDto> GetAllWholeSaleOrdersDto(Expression<Func<GetWholeSaleOrderDto, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var wholeSaleOrderLines = from wholeSaleOrderLine in context.WholeSaleOrderLines
                                      group wholeSaleOrderLine by wholeSaleOrderLine.WholeSaleOrderId
                into wol
                                      select new
                                      {
                                          WholeSaleOrderId = wol.Key,
                                          AmountVatValue = wol.Sum(p => p.VatAmount),
                                          Amount = wol.Sum(p => p.Amount),
                                          AmountWithVat = wol.Sum(p => p.AmountWithVat)
                                      };
            var result = from wholeSaleOrder in context.WholeSaleOrders
                         join partner in context.Partners on wholeSaleOrder.PartnerId equals partner.Id
                         join ledger in context.Ledgers on wholeSaleOrder.LedgerId equals ledger.Id
                         join wholeSaleOrderLine in wholeSaleOrderLines on wholeSaleOrder.Id equals wholeSaleOrderLine
                             .WholeSaleOrderId
                         select new GetWholeSaleOrderDto()
                         {
                             Id = wholeSaleOrder.Id,
                             LedgerId = ledger.Id,
                             PartnerName = partner.Name,
                             WholeSaleOrderNumber = wholeSaleOrder.WholeSaleOrderNumber,
                             LedgerDescription = ledger.Description,
                             RegisterDate = ledger.RegisterDate,
                             IsPaid = wholeSaleOrder.IsPaid,
                             Foreign = wholeSaleOrder.Foreign,
                             AmountVatValue = wholeSaleOrderLine.AmountVatValue,
                             Amount = wholeSaleOrderLine.Amount,
                             AmountWithVat = wholeSaleOrderLine.AmountWithVat
                         };
            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
        }

        public GetWholeSaleOrderDto GetWholeSaleOrderDto(Expression<Func<GetWholeSaleOrderDto, bool>> filter)
        {
            using var context = new InventoryManagementContext();
            var wholeSaleOrderLines = from wholeSaleOrderLine in context.WholeSaleOrderLines
                                      group wholeSaleOrderLine by wholeSaleOrderLine.WholeSaleOrderId
                into wol
                                      select new
                                      {
                                          WholeSaleOrderId = wol.Key,
                                          AmountVatValue = wol.Sum(p => p.VatAmount),
                                          Amount = wol.Sum(p => p.Amount),
                                          AmountWithVat = wol.Sum(p => p.AmountWithVat)
                                      };
            var result = from wholeSaleOrder in context.WholeSaleOrders
                         join partner in context.Partners on wholeSaleOrder.PartnerId equals partner.Id
                         join ledger in context.Ledgers on wholeSaleOrder.LedgerId equals ledger.Id
                         join wholeSaleOrderLine in wholeSaleOrderLines on wholeSaleOrder.Id equals wholeSaleOrderLine
                             .WholeSaleOrderId
                         select new GetWholeSaleOrderDto()
                         {
                             Id = wholeSaleOrder.Id,
                             LedgerId = ledger.Id,
                             PartnerName = partner.Name,
                             WholeSaleOrderNumber = wholeSaleOrder.WholeSaleOrderNumber,
                             LedgerDescription = ledger.Description,
                             RegisterDate = ledger.RegisterDate,
                             IsPaid = wholeSaleOrder.IsPaid,
                             Foreign = wholeSaleOrder.Foreign,
                             AmountVatValue = wholeSaleOrderLine.AmountVatValue,
                             Amount = wholeSaleOrderLine.Amount,
                             AmountWithVat = wholeSaleOrderLine.AmountWithVat
                         };

            return result.FirstOrDefault(filter);
        }

        public List<InvoiceHead> GetAllInvoiceHeads(Expression<Func<InvoiceHead, bool>> filter = null)
        {
            using (var context = new InventoryManagementContext())
            {
                var result = from wholeSaleOrder in context.WholeSaleOrders
                             join ledger in context.Ledgers on wholeSaleOrder.LedgerId equals ledger.Id
                             join partner in context.Partners on wholeSaleOrder.PartnerId equals partner.Id
                             select new InvoiceHead()
                             {
                                 Id = wholeSaleOrder.Id,
                                 LedgerId = ledger.Id,
                                 RegisterDate = ledger.RegisterDate,
                                 Description = wholeSaleOrder.Description,
                                 Foreign = wholeSaleOrder.Foreign,
                                 InvoiceNumber = wholeSaleOrder.WholeSaleOrderNumber,
                                 Note = wholeSaleOrder.Note,
                                 IsPaid = wholeSaleOrder.IsPaid,
                                 PartnerName = partner.Name,
                                 PartnerUniqueIdentificationNumber = partner.UniqueIdentificationNumber,
                                 PartnerVatNumber = partner.VatNumber,
                                 PartnerAddress = partner.Address,
                                 PartnerCity = partner.City,
                                 PartnerCountry = partner.Country,
                                 PartnerEmail = partner.Email,
                                 PartnerPhone = partner.Phone,
                                 PartnerWebsite = partner.Website,
                                 PartnerZipCode = partner.ZipCode
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public InvoiceHead GetByIdInvoiceHead(Expression<Func<InvoiceHead, bool>> filter)
        {
            using (var context = new InventoryManagementContext())
            {
                var result = from wholeSaleOrder in context.WholeSaleOrders
                             join ledger in context.Ledgers on wholeSaleOrder.LedgerId equals ledger.Id
                             join partner in context.Partners on wholeSaleOrder.PartnerId equals partner.Id
                             select new InvoiceHead()
                             {
                                 Id = wholeSaleOrder.Id,
                                 LedgerId = ledger.Id,
                                 RegisterDate = ledger.RegisterDate,
                                 Description = wholeSaleOrder.Description,
                                 Foreign = wholeSaleOrder.Foreign,
                                 InvoiceNumber = wholeSaleOrder.WholeSaleOrderNumber,
                                 Note = wholeSaleOrder.Note,
                                 IsPaid = wholeSaleOrder.IsPaid,
                                 PartnerName = partner.Name,
                                 PartnerUniqueIdentificationNumber = partner.UniqueIdentificationNumber,
                                 PartnerVatNumber = partner.VatNumber,
                                 PartnerAddress = partner.Address,
                                 PartnerCity = partner.City,
                                 PartnerCountry = partner.Country,
                                 PartnerEmail = partner.Email,
                                 PartnerPhone = partner.Phone,
                                 PartnerWebsite = partner.Website,
                                 PartnerZipCode = partner.ZipCode
                             };

                return result.FirstOrDefault(filter);
            }
        }
    }
}
