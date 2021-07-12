using Entity.Concrete;
using Entity.Dto.LedgerEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModel
{
    public class LedgerAccountModel
    {
        public Ledger Ledger { get; set; }
        public List<LedgerEntry> LedgerEntries { get; set; }
    }
}
