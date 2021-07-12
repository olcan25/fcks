using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfAccountDal : EfEntityRepositoryBase<Account, InventoryManagementContext>, IAccountDal
    {
        public List<GetAccountDto> GetAllDtoAccounts(Expression<Func<GetAccountDto, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var result = from account in context.Accounts
                         join accountType in context.AccountTypes on account.AccountTypeId equals accountType.Id
                         select new GetAccountDto
                         {
                             Id = account.Id,
                             Name = account.Name,
                             AccountTypeName = accountType.Name,
                             Description = account.Description,
                             OfficialCode = account.OfficialCode
                         };
            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
        }

        public List<DtoCardOfAccount> GetAllDtoCardOfAccounts(Expression<Func<DtoCardOfAccount, bool>> filter)
        {
            using var context = new InventoryManagementContext();
            var ledgerEntries = from ledger in context.Ledgers
                                join ledgerEntry in context.LedgerEntries on ledger.Id equals ledgerEntry.LedgerId
                                join purchaseOrder in context.PurchaseOrders on ledger.Id equals purchaseOrder.LedgerId into pd
                                from purchaseOrder in pd.DefaultIfEmpty()
                                join wholeSaleOrder in context.WholeSaleOrders on ledger.Id equals wholeSaleOrder.LedgerId into wd
                                from wholeSaleOrder in wd.DefaultIfEmpty()
                                join payment in context.Payments on ledger.Id equals payment.LedgerId into pay
                                from payment in pay.DefaultIfEmpty()
                                select new
                                {
                                    LedgerId = ledger.Id,
                                    AccountId = ledgerEntry.AccountId,
                                    PartnerId =
                                    (payment.PartnerId == null || payment.PartnerId == 0 ? 0 : payment.PartnerId) + (purchaseOrder.PartnerId == null || purchaseOrder.PartnerId == 0 ? 0 : purchaseOrder.PartnerId) + (wholeSaleOrder.PartnerId == null || wholeSaleOrder.PartnerId == 0 ? 0 : wholeSaleOrder.PartnerId),
                                    //payment.PartnerId== 0 ? 0 : payment.PartnerId + purchaseOrder.PartnerId == 0 ? 0 : purchaseOrder.PartnerId + wholeSaleOrder.PartnerId == 0 ? 0 : wholeSaleOrder.PartnerId,
                                    RegisterDate = ledger.RegisterDate,
                                    Debt = ledgerEntry.Debt ?? 0,
                                    Credit = ledgerEntry.Credit ?? 0
                                };

            var result = from ledgerEntry in ledgerEntries
                         join partner in context.Partners on ledgerEntry.PartnerId equals partner.Id
                         into p
                         from partner in p.DefaultIfEmpty()
                         select new DtoCardOfAccount
                         {
                             LedgerId = ledgerEntry.LedgerId,
                             AccountId = ledgerEntry.AccountId,
                             RegisterDate = ledgerEntry.RegisterDate,
                             PartnerName = partner.Name,
                             Debt = ledgerEntry.Debt,
                             Credit = ledgerEntry.Credit,
                             Balance = ledgerEntry.Debt - ledgerEntry.Credit
                         };

            return result.OrderBy(x => x.RegisterDate).Where(filter).ToList();
        }

        public List<DtoConditionOfAccount> GetAllDtoConditionOfAccounts(Expression<Func<DtoConditionOfAccount, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var sumDebts = from ledgerEntry in context.LedgerEntries
                           group ledgerEntry by ledgerEntry.AccountId
                           into debt
                           select new
                           {
                               AccountId = debt.Key,
                               SumDebts = debt.Sum(x => x.Debt)//debt.Where(x => x.EntryType == true).Sum(x => x.Amount)
                           };

            var sumCredits = from ledgerEntry in context.LedgerEntries
                             group ledgerEntry by ledgerEntry.AccountId
               into credit
                             select new
                             {
                                 AccountId = credit.Key,
                                 SumCredits = credit.Sum(x => x.Credit)//credit.Where(x => x.EntryType == false).Sum(x => x.Amount)
                             };

            var result = from account in context.Accounts
                         join sumDebt in sumDebts on account.Id equals sumDebt.AccountId
                         join sumCredit in sumCredits on account.Id equals sumCredit.AccountId
                         select new DtoConditionOfAccount
                         {
                             AccountId = account.Id,
                             AccountName = account.Name,
                             SumDebt = sumDebt.SumDebts ?? 0,
                             SumCredit = sumCredit.SumCredits ?? 0,
                             Balance = (sumDebt.SumDebts ?? 0) - (sumCredit.SumCredits ?? 0)
                         };

            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
        }

        public List<DtoConditionOfAccount> GetAllDtoConditionOfAccounts(DateTime startDate, DateTime endDate, Expression<Func<DtoConditionOfAccount, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var sumDebts = from ledger in context.Ledgers
                           join ledgerEntry in context.LedgerEntries on ledger.Id equals ledgerEntry.LedgerId
                           where ledger.RegisterDate >= startDate && ledger.RegisterDate <= endDate
                           group ledgerEntry by ledgerEntry.AccountId
                           into debt
                           select new
                           {
                               AccountId = debt.Key,
                               SumDebts = debt.Sum(x => x.Debt)//debt.Where(x => x.EntryType == true).Sum(x => x.Amount)
                           };

            var sumCredits = from ledger in context.Ledgers
                             join ledgerEntry in context.LedgerEntries on ledger.Id equals ledgerEntry.LedgerId
                             where ledger.RegisterDate >= startDate && ledger.RegisterDate <= endDate
                             group ledgerEntry by ledgerEntry.AccountId
               into credit
                             select new
                             {
                                 AccountId = credit.Key,
                                 SumCredits = credit.Sum(x => x.Credit)//credit.Where(x => x.EntryType == false).Sum(x => x.Amount)
                             };

            var result = from account in context.Accounts
                         join sumDebt in sumDebts on account.Id equals sumDebt.AccountId
                         join sumCredit in sumCredits on account.Id equals sumCredit.AccountId
                         select new DtoConditionOfAccount
                         {
                             AccountId = account.Id,
                             AccountName = account.Name,
                             SumDebt = sumDebt.SumDebts ?? 0,
                             SumCredit = sumCredit.SumCredits ?? 0,
                             Balance = (sumDebt.SumDebts ?? 0) - (sumCredit.SumCredits ?? 0)
                         };

            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
        }

        public GetAccountDto GetByIdDtoAccount(Expression<Func<GetAccountDto, bool>> filter)
        {
            using var context = new InventoryManagementContext();
            var result = from account in context.Accounts
                         join accountType in context.AccountTypes on account.AccountTypeId equals accountType.Id
                         select new GetAccountDto
                         {
                             Id = account.Id,
                             Name = account.Name,
                             AccountTypeName = accountType.Name,
                             Description = account.Description,
                             OfficialCode = account.OfficialCode
                         };

            return result.FirstOrDefault(filter);
        }
    }
}
