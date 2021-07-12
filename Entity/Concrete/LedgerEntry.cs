using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class LedgerEntry : BaseEntity, IEntity
    {
        public long Id { get; set; }
        public long LedgerId { get; set; }
        public string AccountId { get; set; }
        //public bool EntryType { get; set; }//Debi Or Credit
        //public decimal? Amount { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public decimal? Debt { get; set; }
        public decimal? Credit { get; set; }

        public Ledger Ledger { get; set; }
        public Account Account { get; set; }
    }
}
