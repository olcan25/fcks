using System;
using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class User : BaseEntity, IEntity
    {
        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
