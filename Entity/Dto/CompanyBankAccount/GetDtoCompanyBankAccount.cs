using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.CompanyBankAccount
{
    public class GetDtoCompanyBankAccount : IDto
    {
        public short Id { get; set; }
        public string CompanyName { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string SwiftCode { get; set; }
        public string Iban { get; set; }
    }
}
