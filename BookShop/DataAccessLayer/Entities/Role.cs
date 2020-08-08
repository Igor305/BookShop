using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public List<UserInRole> UserInRoles { get; set; }
    }
}
