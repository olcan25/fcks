using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class UnitOfMeasure : BaseEntity,IEntity
    {
        public UnitOfMeasure()
        {
            Products = new HashSet<Product>();
        }
        public short Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
