using System;
using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Ledger : BaseEntity,IEntity
    {
        public Ledger()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            Payments = new HashSet<Payment>();
            WholeSaleOrders = new HashSet<WholeSaleOrder>();
            LedgerEntries = new HashSet<LedgerEntry>();
        }
        public long Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Description { get; set; }

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public ICollection<WholeSaleOrder> WholeSaleOrders { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<LedgerEntry> LedgerEntries { get; set; }
    }
}
