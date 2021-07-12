using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Invoice
{
    public class InvoiceHead
    {
        public long Id { get; set; }
        public long LedgerId { get; set; }


        public string PartnerName { get; set; }
        public string PartnerUniqueIdentificationNumber { get; set; }
        public string PartnerVatNumber { get; set; }
        public string PartnerCountry { get; set; }
        public string PartnerCity { get; set; }
        public string PartnerAddress { get; set; }
        public string PartnerZipCode { get; set; }
        public string PartnerPhone { get; set; }
        public string PartnerEmail { get; set; }
        public string PartnerWebsite { get; set; }

        public DateTime RegisterDate { get; set; }
        public int InvoiceNumber { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public bool Foreign { get; set; }
        public bool IsPaid { get; set; } = false;
    }
}
