using Business.Abstract.Service;
using Business.IoCHell.Business.Provider.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IoCHell.Business.Provider.Concrete
{
    public class LedgerAccountProvider : ILedgerAccountProvider
    {
        public ILedgerService LedgerService { get; set; }
        public ILedgerEntryService LedgerEntryService { get; set; }

        public LedgerAccountProvider(ILedgerService ledgerService, ILedgerEntryService ledgerEntryService)
        {
            LedgerService = ledgerService;
            LedgerEntryService = ledgerEntryService;
        }
    }
}
