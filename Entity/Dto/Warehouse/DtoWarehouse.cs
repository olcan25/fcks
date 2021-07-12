using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.Warehouse
{
    public class DtoWarehouse : IDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
        public string ZipCode { get; set; }
    }
}
