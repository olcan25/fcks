using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.LedgerEntry
{
    public class LedgerEntryDto
    {
        public long Id { get; set; }
        public long LedgerId { get; set; }
        public string AccountId { get; set; }
        public bool EntryType { get; set; }//Debi Or Credit
        public decimal? Amount { get; set; }
    }
}
