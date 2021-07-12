using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class AccountType : BaseEntity, IEntity
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
