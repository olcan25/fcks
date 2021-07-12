using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.Partner
{
    public class GetDtoPartner : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueIdentificationNumber { get; set; }
        public string VatNumber { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string AdditionalInformation { get; set; }
        public byte[] Logo { get; set; }
    }
}
