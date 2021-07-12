using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.Product
{
    public class DtoConditionOfProduct : IDto
    {
        public long? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? InQuantity { get; set; }
        public decimal? OutQuantity { get; set; }
        public decimal? InFirstUnitPrice { get; set; }
        public decimal? InFirstAmount { get; set; }
        public decimal? InLastUnitPrice { get; set; }
        public decimal? InLastAmount { get; set; }
        public decimal? InAvaregeUnitPrice { get; set; }
        public decimal? InAvarageAmount { get; set; }
        public decimal? OutFirstUnitPrice { get; set; }
        public decimal? OutFirstAmount { get; set; }
        public decimal? OutLastUnitPrice { get; set; }
        public decimal? OutLastAmount { get; set; }
        public decimal? OutUnitPrice { get; set; }
        public decimal? OutAmount { get; set; }
        public decimal? Balance { get; set; }
    }
}
