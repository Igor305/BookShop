using DataAccessLayer.Entities.Base;
using System;

namespace DataAccessLayer.Entities
{
    public class Author : Generic
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime? DateDeath { get; set; }
        
    }
}
