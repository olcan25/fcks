using Core.Entity.Abstract;
using System.Collections.Generic;

namespace Entity.Concrete
{
    public class Bank : BaseEntity, IEntity
    {
        public Bank()
        {
            PartnerBankAccounts = new HashSet<PartnerBankAccount>();
            CompanyBankAccounts = new HashSet<CompanyBankAccount>();
        }
        public short Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public ICollection<PartnerBankAccount> PartnerBankAccounts { get; set; }
        public ICollection<CompanyBankAccount> CompanyBankAccounts { get; set; }
    }
}
