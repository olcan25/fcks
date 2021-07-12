
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class PaymentType:BaseEntity,IEntity
    {
        public PaymentType()
        {
            Payments = new HashSet<Payment>();
        }
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
