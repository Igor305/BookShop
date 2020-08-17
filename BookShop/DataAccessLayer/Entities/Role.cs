using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserInRole> UserInRoles { get; set; }
    }
}
