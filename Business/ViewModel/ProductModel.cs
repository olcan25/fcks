using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.ViewModel
{
    public class ProductModel
    {
        public Product Product { get; set; }
        public List<ProductBarcode> ProductBarcodes { get; set; }
    }
}
