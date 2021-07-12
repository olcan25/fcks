using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.LedgerEntry
{
    public class LedgerEntryDebtCredit : IDto
    {
        public long Id { get; set; }
        public long LedgerId { get; set; }
        public string AccountId { get; set; }
        public decimal? Debt { get; set; }
        public decimal? Credit { get; set; }
    }
}