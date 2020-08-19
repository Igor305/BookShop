using BusinessLogicLayer.Models.Base;
using System;

namespace BusinessLogicLayer.Models.Author
{
    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime? DateDeath { get; set; }

    }
}
