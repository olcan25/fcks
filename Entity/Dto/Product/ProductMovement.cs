using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;

namespace Entity.Dto.Product
{
    public class ProductMovement:IDto
    {
        public string ProductName { get; set; }
        public string WarehouseName { get; set; }
        public float In { get; set; }
        public float Out { get; set; }
        public float UnitPrice { get; set; }
        public float UnitPriceWithVat { get; set; }
    }
}
