using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.Product
{
    public class GetDtoProduct : IDto
    {
        public int Id { get; set; }
        public string VatName { get; set; }
        public string CategoryName { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal DefaultBuyingPrice { get; set; } = 0;
        public decimal DefaultSellingPrice { get; set; } = 0;
    }
}
