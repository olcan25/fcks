using Business.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IoCHell.Business.Provider.Abstract
{
    public interface ILedgerAccountProvider
    {
        public ILedgerService LedgerService { get; set; }
        public ILedgerEntryService LedgerEntryService { get; set; }
    }
}