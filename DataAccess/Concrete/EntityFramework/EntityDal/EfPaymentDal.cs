using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.Dto.Payment;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, InventoryManagementContext>, IPaymentDal
    {
        public List<GetPaymentDto> GetAllPaymentDtoJoins(Expression<Func<GetPaymentDto, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var result = from payment in context.Payments
                         join account in context.Accounts on payment.AccountId equals account.Id
                         join ledger in context.Ledgers on payment.LedgerId equals ledger.Id
                         join partner in context.Partners on payment.PartnerId equals partner.Id
                         join paymentType in context.PaymentTypes on payment.PaymentTypeId equals paymentType.Id
                         select new GetPaymentDto
                         {
                             Id = payment.Id,
                             LedgerId = ledger.Id,
                             PaymentTypeId = paymentType.Id,
                             AccountName = account.Name,
                             LedgerDescription = ledger.Description,
                             RegisterDate = ledger.RegisterDate,
                             PartnerName = partner.Name,
                             Note = payment.Note,
                             PaymentDescription = payment.Description,
                             PaymentType = paymentType.Name,
                             Amount = (decimal)payment.Amount
                         };

            return filter == null
            ? result.ToList()
            : result.Where(filter).ToList();

        }

        public GetPaymentDto GetByIdPaymentDtoJoin(Expression<Func<GetPaymentDto, bool>> filter)
        {
            using var context = new InventoryManagementContext();
            var result = from payment in context.Payments
                         join account in context.Accounts on payment.AccountId equals account.Id into a
                         from account in a.DefaultIfEmpty()
                         join ledger in context.Ledgers on payment.LedgerId equals ledger.Id into l
                         from ledger in l.DefaultIfEmpty()
                         join partner in context.Partners on payment.PartnerId equals partner.Id into p
                         from partner in p.DefaultIfEmpty()
                         //join paymentType in context.PaymentTypes on payment.PaymentTypeId equals paymentType.Id
                         select new GetPaymentDto
                         {
                             Id = payment.Id,
                             LedgerId = ledger.Id,
                             //PaymentTypeId = paymentType.Id,
                             AccountName = account.Name,
                             LedgerDescription = ledger.Description,
                             RegisterDate = ledger.RegisterDate,
                             PartnerName = partner.Name,
                             Note = payment.Note,
                             PaymentDescription = payment.Description,
                             //PaymentType = paymentType.Name,
                             Amount = payment.Amount
                         };

            return result.FirstOrDefault(filter);
        }
    }
}
