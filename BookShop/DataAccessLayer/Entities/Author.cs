using DataAccessLayer.Entities.Base;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Author : Generic
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime? DateDeath { get; set; }
        
        public List<AuthorInPrintingEdition> AuthorInPrintingEditions { get; set; }
    }
}
