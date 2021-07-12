using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
