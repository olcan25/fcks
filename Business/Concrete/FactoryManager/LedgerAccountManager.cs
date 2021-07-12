using AutoMapper;
using Business.Abstract.FactoryService;
using Business.IoCHell.Business.Factory.Abstract;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.FactoryManager
{
    public class LedgerAccountManager : ILedgerAccountService
    {
        private readonly ILedgerAccountFactory _ledgerAccountFactory;
        private readonly IMapper _mapper;
        public LedgerAccountManager(ILedgerAccountFactory ledgerAccountFactory, IMapper mapper)
        {
            _ledgerAccountFactory = ledgerAccountFactory;
            _mapper = mapper;
        }

        [TransactionScopeAspect]
        public IResult Add(Ledger ledger, List<LedgerEntry> ledgerEntries)
        {
            ledgerEntries.RemoveAll(x => x.AccountId == null || x.AccountId == "" || x.Debt == 0 && x.Credit == 0);
            _ledgerAccountFactory.Create().LedgerService.Add(ledger);
            foreach (var ledgerEntry in ledgerEntries)
            {
                ledgerEntry.LedgerId = ledger.Id;
            }

            _ledgerAccountFactory.Create().LedgerEntryService.AddBulk(ledgerEntries);

            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        public IResult Delete(long id)
        {
            var ledgerEntries = _ledgerAccountFactory.Create().LedgerEntryService.GetAllByLedgerIdLedgerEntries(id).Data;
            _ledgerAccountFactory.Create().LedgerEntryService.DeleteBulk(ledgerEntries);
            var ledger = _ledgerAccountFactory.Create().LedgerService.GetByIdLedger(id).Data;
            _ledgerAccountFactory.Create().LedgerService.Delete(ledger);
            return new SuccessResult(Messages.Deleted);
        }

        [TransactionScopeAspect]
        public IResult Update(Ledger ledger, List<LedgerEntry> ledgerEntries)
        {
            ledgerEntries.RemoveAll(x => x.AccountId == null || x.AccountId == "" || x.Debt == 0 && x.Credit == 0);
            _ledgerAccountFactory.Create().LedgerService.Update(ledger);
            foreach (var ledgerEntry in ledgerEntries)
            {
                ledgerEntry.LedgerId = ledger.Id;
            }
            _ledgerAccountFactory.Create().LedgerEntryService.UpdateBulk(ledgerEntries);
            return new SuccessResult(Messages.Modified);
        }
    }
}
