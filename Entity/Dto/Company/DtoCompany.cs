using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.Company
{
    public class DtoCompany : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueIdentificationNumber { get; set; }
        public string VatNumber { get; set; }
        public byte[] Logo { get; set; }
        public short Period { get; set; }
    }
}
