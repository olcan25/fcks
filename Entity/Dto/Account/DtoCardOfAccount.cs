using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Account
{
    public class DtoCardOfAccount : IDto
    {
        public long LedgerId { get; set; }
        public string AccountId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string PartnerName { get; set; }
        public decimal? Debt { get; set; }
        public decimal Credit { get; set; }
        public decimal? Balance { get; set; }
    }
}
