using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.ProductImage
{
    public class ProductImageForReturn
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string PublicId { get; set; }
    }
}
