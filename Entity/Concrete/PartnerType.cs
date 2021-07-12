using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class PartnerType:BaseEntity,IEntity
    {
        public PartnerType()
        {
            Partners = new HashSet<Partner>();
        }
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<Partner> Partners { get; set; }
    }
}
