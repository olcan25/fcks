using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class WarehouseType : BaseEntity, IEntity
    {
        public WarehouseType()
        {
            Warehouses = new HashSet<Warehouse>();
        }
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }
    }
}
