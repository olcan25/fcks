using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;

namespace Entity.Dto.PurchaseOrder
{
    public class GetPurchaseOrderDto : IDto
    {
        public long Id { get; set; }
        public long LedgerId { get; set; }

        public DateTime RegisterDate { get; set; }
        public string PartnerName { get; set; }

        public string InvoiceNumber { get; set; }
        public string Note { get; set; }
        public string PurchaseOrderDescription { get; set; }
        public string LedgerDescription { get; set; }
        public bool IsPaid { get; set; }
        public decimal? AmountVatValue { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountWithVat { get; set; }
    }
}
