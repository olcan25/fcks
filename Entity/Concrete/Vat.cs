using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Vat : BaseEntity, IEntity
    {
        public Vat()
        {
            Products = new HashSet<Product>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            WholeSaleOrderLines = new HashSet<WholeSaleOrderLine>();
        }
        public byte Id { get; set; }
        public string Name { get; set; }
        public float Rate { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public ICollection<WholeSaleOrderLine> WholeSaleOrderLines { get; set; }
    }
}
