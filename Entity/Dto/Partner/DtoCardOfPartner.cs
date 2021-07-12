using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.Partner
{
    public class DtoCardOfPartner : IDto
    {
        public long LedgerId { get; set; }
        public DateTime RegisterDate { get; set; }
        public long PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string Description { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal? Debt { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Balance { get; set; }
    }
}
