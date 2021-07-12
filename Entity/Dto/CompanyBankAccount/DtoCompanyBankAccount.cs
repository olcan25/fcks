using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.CompanyBankAccount
{
    public class DtoCompanyBankAccount : IDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public short BankId { get; set; }
        public string AccountNumber { get; set; }
    }
}
