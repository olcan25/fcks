using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Warehouse : BaseEntity, IEntity
    {
        public Warehouse()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            WholeSaleOrderLines = new HashSet<WholeSaleOrderLine>();
        }

        public int Id { get; set; }
        public short CompanyId { get; set; }
        public short WarehouseTypeId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
        public string ZipCode { get; set; }

        public Company Company { get; set; }
        public WarehouseType WarehouseType { get; set; }
        public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public ICollection<WholeSaleOrderLine> WholeSaleOrderLines { get; set; }
    }
}
