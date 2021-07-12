using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class ProductType:BaseEntity,IEntity
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
