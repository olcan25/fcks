using System;
using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class WholeSaleOrder : BaseEntity, IEntity
    {
        public WholeSaleOrder()
        {
            WholeSaleOrderLines = new HashSet<WholeSaleOrderLine>();
        }

        public long Id { get; set; }
        public long LedgerId { get; set; }
        public long PartnerId { get; set; }
        public short CurrencyId { get; set; }

        public int WholeSaleOrderNumber { get; set; }

        public string Description { get; set; }
        public string Note { get; set; }
        public bool Foreign { get; set; }
        public bool IsPaid { get; set; } = false;

        public Ledger Ledger { get; set; }
        public Partner Partner { get; set; }
        public Currency Currency { get; set; }

        public ICollection<WholeSaleOrderLine> WholeSaleOrderLines { get; set; }
    }
}
