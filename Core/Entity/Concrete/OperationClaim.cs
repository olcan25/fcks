using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class OperationClaim : BaseEntity, IEntity
    {
        public OperationClaim()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
