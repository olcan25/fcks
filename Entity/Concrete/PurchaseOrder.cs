using System;
using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class PurchaseOrder : BaseEntity, IEntity
    {
        public PurchaseOrder()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
        }
        public long Id { get; set; }
        public long LedgerId { get; set; }
        public long PartnerId { get; set; }
        public long? TransporterId { get; set; }
        public short CurrencyId { get; set; }

        public decimal? CurrencyRate { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomsNumber { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }


        public Partner Partner { get; set; }
        public Partner Transporter { get; set; }
        public Ledger Ledger { get; set; }
        public Currency Currency { get; set; }
        public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    }
}
