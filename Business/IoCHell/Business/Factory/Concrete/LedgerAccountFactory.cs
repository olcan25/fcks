using Business.Abstract.Service;
using Business.IoCHell.Business.Factory.Abstract;
using Business.IoCHell.Business.Provider.Abstract;
using Business.IoCHell.Business.Provider.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IoCHell.Business.Factory.Concrete
{
    public class LedgerAccountFactory : ILedgerAccountFactory
    {
        private readonly ILedgerService _ledgerService;
        private readonly ILedgerEntryService _ledgerEntryService;

        public LedgerAccountFactory(ILedgerService ledgerService, ILedgerEntryService ledgerEntryService)
        {
            _ledgerService = ledgerService;
            _ledgerEntryService = ledgerEntryService;
        }

        public ILedgerAccountProvider Create()
        {
            return new LedgerAccountProvider(_ledgerService, _ledgerEntryService);
        }
    }
}
