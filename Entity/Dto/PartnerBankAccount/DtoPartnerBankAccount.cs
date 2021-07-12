using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.PartnerBankAccount
{
    public class DtoPartnerBankAccount : IDto
    {
        public int Id { get; set; }
        public string PartnerName { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string Iban { get; set; }
        public string SwiftCode { get; set; }
    }
}
