using System;

namespace DataAccessLayer.Entities
{
    public class UserInRole
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
