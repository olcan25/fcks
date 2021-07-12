using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;
using Entity.Concrete;

namespace Entity.Dto.Product
{
    public class DtoProduct : IDto
    {
        public long Id { get; set; }
        public string VatRate { get; set; }
        public string CategoryName { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string ProductTypeName { get; set; }
        public float? CustomsRate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? DefaultBuyingPrice { get; set; } = 0;
        public decimal? DefaultSellingPrice { get; set; } = 0;
        public string ImagePath { get; set; }
    }
}
