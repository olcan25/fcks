using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.PartnerBankAccount
{
    public class PartnerByIdBankAccount : IDto
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
    }
}
