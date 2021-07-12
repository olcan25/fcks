using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.Product
{
    public class DtoCardOfProduct : IDto
    {
        public long? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? InQuantity { get; set; }
        public decimal? OutQuantity { get; set; }
        public decimal? Balance { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitPriceWithVat { get; set; }
        public string PartnerName { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
