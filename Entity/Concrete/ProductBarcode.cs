using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class ProductBarcode:BaseEntity,IEntity
    {
        public int Id { get; set; }
        public long ProductId { get; set; }
        public string Barcode { get; set; }
        
        public Product Product { get; set; }
    }
}
