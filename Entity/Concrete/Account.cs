using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Account : BaseEntity, IEntity
    {
        public Account()
        {
            LedgerEntries = new HashSet<LedgerEntry>();
            Payments = new HashSet<Payment>();
        }
        public string Id { get; set; }
        public byte? AccountTypeId { get; set; }
        public string Name { get; set; }
        public string OfficialCode { get; set; }
        public string Description { get; set; }

        public ICollection<LedgerEntry> LedgerEntries { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public AccountType AccountType { get; set; }
    }
}
