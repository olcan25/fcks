using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Currency : BaseEntity, IEntity
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string ShortName { get; set; }

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public ICollection<WholeSaleOrder> WholeSaleOrders { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
