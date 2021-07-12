using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class UserOperationClaim : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
