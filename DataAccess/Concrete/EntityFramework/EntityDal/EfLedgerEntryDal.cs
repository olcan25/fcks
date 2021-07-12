using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using Entity.Dto.LedgerEntry;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfLedgerEntryDal : EfEntityRepositoryBase<LedgerEntry, InventoryManagementContext>, ILedgerEntryDal
    {
        public override void BulkSynchronize(List<LedgerEntry> entities, BulkConfig bulkConfig = null)
        {
            using var context = new InventoryManagementContext();
            long ledgerId = entities.Select(ledgerEntry => ledgerEntry.LedgerId).FirstOrDefault();
            //bulkConfig.SetSynchronizeFilter<LedgerEntry>(x => x.LedgerId == ledgerId);
            //context.BulkInsertOrUpdateOrDelete<LedgerEntry>(entities, bulkConfig);

            context.LedgerEntries.ToLinqToDBTable()
                .Merge()
                     .Using(entities)
                     .On((t, s) => t.Id == s.Id)
                     .UpdateWhenMatchedAnd((t, s) => t.Id == s.Id)
                     .InsertWhenNotMatched()
                     .DeleteWhenNotMatchedBySourceAnd(p => p.LedgerId == ledgerId)
                     .Merge();
        }

        public List<LedgerAccountDto> GetAllLedgerAccountsDto(Expression<Func<LedgerAccountDto, bool>> filter = null)
        {
            using var context = new InventoryManagementContext();
            var result = from ledger in context.Ledgers
                         join ledgerEntry in context.LedgerEntries on ledger.Id equals ledgerEntry.LedgerId
                         join account in context.Accounts on ledgerEntry.AccountId equals account.Id
                         group new { ledger, ledgerEntry } by new { ledger.Id, ledger.RegisterDate, ledger.Description } into l
                         select new LedgerAccountDto
                         {
                             //LedgerId = ledger.Id,
                             //AccountId = account.Id,
                             //LedgerEntryId = ledgerEntry.Id,
                             //AccountName = account.Name,
                             //RegisterDate = ledger.RegisterDate,
                             //LedgerDescription = ledger.Description,
                             //Debt = ledgerEntry.Debt ?? 0,//ledgerEntry.EntryType == true ? ledgerEntry.Amount : 0,
                             //Credit = ledgerEntry.Credit ?? 0,//ledgerEntry.EntryType == false ? ledgerEntry.Amount : 0,
                             //Balance = (ledgerEntry.Debt ?? 0) - (ledgerEntry.Credit ?? 0)//ledgerEntry.EntryType == true ? ledgerEntry.Amount : 0 - (ledgerEntry.EntryType == false ? ledgerEntry.Amount : 0)
                             LedgerId = l.Key.Id,
                             RegisterDate = l.Key.RegisterDate,
                             Debt = l.Sum(x => x.ledgerEntry.Debt),
                             Credit = l.Sum(x => x.ledgerEntry.Credit),
                             Balance = l.Sum(x => x.ledgerEntry.Debt ?? 0) - l.Sum(x => x.ledgerEntry.Credit ?? 0),
                             LedgerDescription = l.Key.Description

                         };

            result = result.OrderBy(x => x.RegisterDate).OrderBy(x => x.LedgerId);

            return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
        }

        public LedgerAccountDto GetByLEdgerAccountDto(Expression<Func<LedgerAccountDto, bool>> filter)
        {
            using var context = new InventoryManagementContext();
            var result = from ledger in context.Ledgers
                         join ledgerEntry in context.LedgerEntries on ledger.Id equals ledgerEntry.LedgerId
                         join account in context.Accounts on ledgerEntry.AccountId equals account.Id
                         select new LedgerAccountDto
                         {
                             LedgerId = ledger.Id,
                             AccountId = account.Id,
                             LedgerEntryId = ledgerEntry.Id,
                             AccountName = account.Name,
                             RegisterDate = ledger.RegisterDate,
                             LedgerDescription = ledger.Description,
                             Debt = ledgerEntry.Debt ?? 0,//ledgerEntry.EntryType == true ? ledgerEntry.Amount : 0,
                             Credit = ledgerEntry.Credit ?? 0,//ledgerEntry.EntryType == false ? ledgerEntry.Amount : 0,
                             Balance = (ledgerEntry.Debt ?? 0) - (ledgerEntry.Credit ?? 0)//ledgerEntry.EntryType == true ? ledgerEntry.Amount : 0 - (ledgerEntry.EntryType == false ? ledgerEntry.Amount : 0)
                         };

            return result.FirstOrDefault(filter);
        }
    }
}
